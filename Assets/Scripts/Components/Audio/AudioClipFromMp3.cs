using System;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave;

public static class AudioClipFromMp3
{
    public static AudioClip FromBytes(byte[] bytes)
    {
        MemoryStream mp3Stream = new MemoryStream(bytes);
        Mp3FileReader mp3Audio = new Mp3FileReader(mp3Stream);
        WaveStream waveStream  = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
        
        return ByteArrayToAudioClip( WaveToMemoryStream(waveStream).ToArray());
    }

    private static MemoryStream WaveToMemoryStream(WaveStream waveStream)
    {
        MemoryStream outputStream = new MemoryStream();
        using (WaveFileWriter waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
        {
            byte[] bytes = new byte[waveStream.Length];
            waveStream.Read(bytes, 0, (int) waveStream.Length);
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();
        }
        return outputStream;
    }

    private static AudioClip ByteArrayToAudioClip(byte[] wavFile)
    {
        if (BitConverter.ToInt16(wavFile, 20) != 1) throw new Exception("Byte at index 20 is not 1");
        int numChannels   = BitConverter.ToInt16(wavFile, 22);
        int bitsPerSample = BitConverter.ToInt16(wavFile, 34);
        int sampleRate    = BitConverter.ToInt32(wavFile, 24);
        int dataIndex     = BitConverter.ToInt32(wavFile, 16);

        dataIndex.FindDataIndex(ref wavFile);
        
        int subChunk2Size   = BitConverter.ToInt32(wavFile, dataIndex); 
        int sampleSize      = bitsPerSample / 8; 
        int sampleCount     = subChunk2Size / sampleSize;
        float[] audioBuffer = new float[sampleCount];
        
        Parallel.For(0, sampleCount, i => audioBuffer[i] = BitConverter.ToInt16(wavFile, dataIndex + 4 + i * sampleSize) / 32768.0f);

        AudioClip audioClip = AudioClip.Create("Default", sampleCount, numChannels, sampleRate, false);
        audioClip.SetData(audioBuffer, 0);
        
        return audioClip;
    }

    private static void FindDataIndex(this ref int index, ref byte[] wavFile)
    {
        for (int i = index + 20; i < wavFile.Length; i++)
        {
            if (wavFile[i - 4] == 'd' && wavFile[i - 3] == 'a' && wavFile[i - 2] == 't' && wavFile[i - 1] == 'a')
            {
                index = i;
                return;
            }
        }
        throw new Exception("Data Index not found");
    }
}