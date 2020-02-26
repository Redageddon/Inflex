using UnityEngine;
using System.IO;
using System;
using NAudio.Wave;

public static class NAudioPlayer
{
    public static AudioClip FromMp3Data(byte[] data)
    {
        // Load the data into a stream
        var mp3Stream = new MemoryStream(data);
        // Convert the data in the stream to WAV format
        var mp3Audio = new Mp3FileReader(mp3Stream);
        WaveStream waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
        // Convert to WAV data
        var wav = new Wav(AudioMemStream(waveStream).ToArray());

        AudioClip audioClip;
        if (wav.ChannelCount == 2)
        {
            audioClip = AudioClip.Create("Audio File Name", wav.SampleCount, 2, wav.Frequency, false);
            audioClip.SetData(wav.StereoChannel, 0);
        }
        else
        {
            audioClip = AudioClip.Create("Audio File Name", wav.SampleCount, 1, wav.Frequency, false);
            audioClip.SetData(wav.LeftChannel, 0);
        }

        // Now return the clip
        return audioClip;
    }

    private static MemoryStream AudioMemStream(WaveStream waveStream)
    {
        var outputStream = new MemoryStream();
        using (WaveFileWriter waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
        {
            var bytes = new byte[waveStream.Length];
            waveStream.Read(bytes, 0, (int)waveStream.Length);
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();
        }

        return outputStream;
    }
}