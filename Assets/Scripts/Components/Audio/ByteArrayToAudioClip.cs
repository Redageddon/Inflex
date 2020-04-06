using System;
using UnityEngine;

public class ByteArrayToAudioClip
{
    public readonly AudioClip AudioClip;
    public ByteArrayToAudioClip(byte[] wavFile)
    {
        if (BitConverter.ToInt16(wavFile, 20) != 1) return;
        int numChannels = BitConverter.ToInt16(wavFile, 22);
        int bitsPerSample = BitConverter.ToInt16(wavFile, 34);
        var sampleRate = BitConverter.ToInt32(wavFile, 24);
        var dataIndex = 20 + BitConverter.ToInt32(wavFile, 16);
        
        for (; dataIndex < wavFile.Length; dataIndex++)
        {
            if (wavFile[dataIndex - 4] == 'd' && wavFile[dataIndex - 3] == 'a' && wavFile[dataIndex - 2] == 't' && wavFile[dataIndex - 1] == 'a') break;
        }
        
        var subChunk2Size = BitConverter.ToInt32(wavFile, dataIndex); 
        int sampleSize = bitsPerSample / 8; 
        int sampleCount = subChunk2Size / sampleSize;
        var audioBuffer = new float[sampleCount];

        for (var i = 0; i < sampleCount; i++)
        {
            int sampleIndex = dataIndex + 4 + i * sampleSize;
            audioBuffer[i] = BitConverter.ToInt16(wavFile, sampleIndex) / 32768.0f;
        }
        
        var audioClip = AudioClip.Create("Default", sampleCount, numChannels, sampleRate, false);
        audioClip.SetData(audioBuffer, 0);
        AudioClip = audioClip;
    }
}