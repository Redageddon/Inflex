using System;
using UnityEngine;
using System.IO;
using NAudio.Wave;

public static class Mp3ToAudioClip
{
    public static AudioClip FromMp3Bytes(byte[] bytes)
    {
        MemoryStream mp3Stream = new MemoryStream(bytes);
        Mp3FileReader mp3Audio = new Mp3FileReader(mp3Stream);
        WaveStream waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);

        return ByteArrayToAudioClip(WaveToMemoryStream(waveStream).ToArray());
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
        _wavFile = wavFile;
        int numChannels = BitConverter.ToInt16(wavFile, 22);
        int bitsPerSample = BitConverter.ToInt16(wavFile, 34);
        int sampleRate = BitConverter.ToInt32(wavFile, 24);
        _dataIndex = BitConverter.ToInt32(wavFile, 16) + 20;

        FindDataIndex();

        int subChunk2Size = BitConverter.ToInt32(wavFile, _dataIndex);
        _sampleSize = bitsPerSample / 8;
        int sampleCount = subChunk2Size / _sampleSize;

        AudioClip audioClip = AudioClip.Create("Default", sampleCount, numChannels, sampleRate, true, OnAudioRead, OnAudioSetPosition);

        return audioClip;
    }

    private static int _position;
    private static byte[] _wavFile;
    private static int _dataIndex;
    private static int _sampleSize;
    private static void OnAudioSetPosition(int newPosition) => _position = newPosition;

    private static void OnAudioRead(float[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = BitConverter.ToInt16(_wavFile, _dataIndex + 4 + _position * _sampleSize) / 32768.0f;
            _position++;
        }
    }

    private static void FindDataIndex()
    {
        for (int i = _dataIndex; i < _wavFile.Length; i++)
        {
            if (_wavFile[i - 4] == 'd' && _wavFile[i - 3] == 'a' && _wavFile[i - 2] == 't' && _wavFile[i - 1] == 'a')
            {
                _dataIndex = i;
                return;
            }
        }
        throw new Exception("Data Index not found");
    }
}