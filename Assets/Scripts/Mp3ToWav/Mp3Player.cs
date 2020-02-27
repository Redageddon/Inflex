using UnityEngine;
using System.IO;
using NAudio.Wave;

public static class Mp3Player
{
    private static AudioClip ByteArrayToAudioClip(byte[] wavFile, string name = "", bool stream = false)
    {
        if (System.BitConverter.ToInt16(wavFile, 20) != 1) return null;
        int numChannels = System.BitConverter.ToInt16(wavFile, 22);
        int bitsPerSample = System.BitConverter.ToInt16(wavFile, 34);
        var sampleRate = System.BitConverter.ToInt32(wavFile, 24);
        var dataIndex = 20 + System.BitConverter.ToInt32(wavFile, 16);
        
        for (; dataIndex < wavFile.Length; dataIndex++)
        {
            if (wavFile[dataIndex - 4] == 'd' && wavFile[dataIndex - 3] == 'a' && wavFile[dataIndex - 2] == 't' && wavFile[dataIndex - 1] == 'a') break;
        }
        
        var subChunk2Size = System.BitConverter.ToInt32(wavFile, dataIndex); 
        int sampleSize = bitsPerSample / 8; 
        int sampleCount = subChunk2Size / sampleSize;
        var audioBuffer = new float[sampleCount];

        for (var i = 0; i < sampleCount; i++)
        {
            int sampleIndex = dataIndex + 4 + i * sampleSize;
            audioBuffer[i] = System.BitConverter.ToInt16(wavFile, sampleIndex) / 32768.0f;
        }
        
        var audioClip = AudioClip.Create(name, sampleCount, numChannels, sampleRate, stream);
        audioClip.SetData(audioBuffer, 0);
        return audioClip;
    }

    public static AudioClip AudioClipFromMp3(byte[] bytes)
    {
        var mp3Stream = new MemoryStream(bytes);
        var mp3Audio = new Mp3FileReader(mp3Stream);
        var waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
        return ByteArrayToAudioClip(AudioMemStream(waveStream).ToArray());
    }

    private static MemoryStream AudioMemStream(WaveStream waveStream)
    {
        var outputStream = new MemoryStream();
        using (var waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
        {
            var bytes = new byte[waveStream.Length];
            waveStream.Read(bytes, 0, (int) waveStream.Length);
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();
        }

        return outputStream;
    }
}