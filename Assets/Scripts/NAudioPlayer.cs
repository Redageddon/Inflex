using System;
using System.IO;
using NAudio.Wave;
using UnityEngine;

public static class NAudioPlayer 
{
    private class Wav
    {
        public float[] LeftChannel { get; }
        public float[] RightChannel { get; }
        public float[] StereoChannel { get; }
        public int ChannelCount { get; }
        public int SampleCount { get; }
        public int Frequency { get; }

        private static float BytesToFloat(byte firstByte, byte secondByte)
        {
            short s = (short)((secondByte << 8) | firstByte);
            return s / 32768.0F;
        }
        
        private static int BytesToInt(byte[] bytes, int offset = 0)
        {
            var value = 0;
            for (int i = 0; i < 4; i++)
            {
                value |= bytes[offset + i] << (i * 8);
            }
            return value;
        }
        
        public Wav(byte[] wav)
        {
            ChannelCount = wav[22];
            Frequency = BytesToInt(wav, 24);
            int pos = 12; 
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;
            SampleCount = (wav.Length - pos) / 2;
            if (ChannelCount == 2)
                SampleCount /= 2;
            LeftChannel = new float[SampleCount];
            RightChannel = ChannelCount == 2 ? new float[SampleCount] : null;

            int i = 0;
            while (pos < wav.Length)
            {
                LeftChannel[i] = BytesToFloat(wav[pos], wav[pos + 1]);
                pos += 2;
                if (ChannelCount == 2)
                {
                    RightChannel[i] = BytesToFloat(wav[pos], wav[pos + 1]);
                    pos += 2;
                }
                i++;
            }

            if (ChannelCount == 2)
            {
                StereoChannel = new float[SampleCount * 2];
                int channelPos = 0;
                short posChange = 0;
                for (int index = 0; index < (SampleCount * 2); index++)
                {
                    if (index % 2 == 0)
                    {
                        StereoChannel[index] = LeftChannel[channelPos];
                        posChange++;
                    }
                    else
                    {
                        StereoChannel[index] = RightChannel[channelPos];
                        posChange++;
                    }

                    if (posChange % 2 != 0) continue;
                    if (channelPos >= SampleCount) continue;
                    channelPos++;
                    posChange = 0;
                }
            }
            else
            {
                StereoChannel = null;
            }
        }
        
        public override string ToString()
        {
            return string.Format("[WAV: LeftChannel={0}, RightChannel={1}, ChannelCount={2}, SampleCount={3}, Frequency={4}]", LeftChannel, RightChannel, ChannelCount, SampleCount, Frequency);
        }
    }
    

    private static MemoryStream AudioMemStream(WaveStream waveStream)
    {
        MemoryStream outputStream = new MemoryStream();
        using (WaveFileWriter waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
        {
            byte[] bytes = new byte[waveStream.Length];
            waveStream.Position = 0;
            waveStream.Read(bytes, 0, Convert.ToInt32(waveStream.Length));
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();
        }
        return outputStream;
    }
    
    public static AudioClip FromMp3Data(byte[] data)
    {
        MemoryStream mp3Stream = new MemoryStream(data);
        Mp3FileReader mp3Audio = new Mp3FileReader(mp3Stream);
        WaveStream waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
        Wav wav = new Wav(AudioMemStream(waveStream).ToArray());
        AudioClip audioClip = null;
        if (wav.ChannelCount == 2)
        {
            audioClip = AudioClip.Create("audio file name", wav.SampleCount, 2, wav.Frequency, false);
            audioClip.SetData(wav.StereoChannel, 0);
        }
        else
        {
            audioClip = AudioClip.Create("audio file name", wav.SampleCount, 1, wav.Frequency, false);
            audioClip.SetData(wav.LeftChannel, 0);
        }

        return audioClip;
    }
}