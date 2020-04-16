using System;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave;

public class AudioClipFromMp3
{
    public static AudioClip FromBytes(byte[] bytes)
    {
        MemoryStream mp3Stream = new MemoryStream(bytes);
        Mp3FileReader mp3Audio = new Mp3FileReader(mp3Stream);
        WaveStream waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
        
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
        if (BitConverter.ToInt16(wavFile, 20) != 1) return null;
        int numChannels = BitConverter.ToInt16(wavFile, 22);
        int bitsPerSample = BitConverter.ToInt16(wavFile, 34);
        int sampleRate = BitConverter.ToInt32(wavFile, 24);
        int dataIndex = 20 + BitConverter.ToInt32(wavFile, 16);
        
        for (; dataIndex < wavFile.Length; dataIndex++)
        {
            if (wavFile[dataIndex - 4] == 'd' && wavFile[dataIndex - 3] == 'a' && wavFile[dataIndex - 2] == 't' && wavFile[dataIndex - 1] == 'a') break;
        }
        
        int subChunk2Size = BitConverter.ToInt32(wavFile, dataIndex); 
        int sampleSize = bitsPerSample / 8; 
        int sampleCount = subChunk2Size / sampleSize;
        float[] audioBuffer = new float[sampleCount];
        
        Parallel.For(0, sampleCount, i => audioBuffer[i] = BitConverter.ToInt16(wavFile, dataIndex + 4 + i * sampleSize) / 32768.0f);

        AudioClip audioClip = AudioClip.Create("Default", sampleCount, numChannels, sampleRate, false);
        audioClip.SetData(audioBuffer, 0);
        
        return audioClip;
    }
}