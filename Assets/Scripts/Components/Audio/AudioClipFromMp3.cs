using UnityEngine;
using System.IO;
using NAudio.Wave;

public class AudioClipFromMp3
{
    public readonly AudioClip AudioClip;
    public AudioClipFromMp3(byte[] bytes)
    {
        var mp3Stream = new MemoryStream(bytes);
        var mp3Audio = new Mp3FileReader(mp3Stream);
        var waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);

        AudioClip = new ByteArrayToAudioClip(new WaveToMemoryStream(waveStream).Stream.ToArray()).AudioClip;
    }
}