using System;
using System.IO;
using NAudio.Wave;
using UnityEngine;

namespace Audio
{
    public static class Mp3ToAudioClip
    {
        private static          int           position;
        private static          byte[]        wavFile;
        private static          int           dataStartIndex;
        private static          int           sampleSize;

        public static AudioClip FromMp3Bytes(byte[] bytes)
        {
            MemoryStream        mp3Stream  = new MemoryStream(bytes);
            using Mp3FileReader mp3Audio   = new Mp3FileReader(mp3Stream);
            using WaveStream    waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio);
            return ByteArrayToAudioClip(WaveToMemoryStream(waveStream).ToArray());
        }

        private static MemoryStream WaveToMemoryStream(WaveStream waveStream)
        {
            MemoryStream         outputStream   = new MemoryStream();
            using WaveFileWriter waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat);
            var                  bytes          = new byte[waveStream.Length];
            waveStream.Read(bytes, 0, (int)waveStream.Length);
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();

            return outputStream;
        }

        private static AudioClip ByteArrayToAudioClip(byte[] array)
        {
            if (BitConverter.ToInt16(array, 20) != 1)
            {
                throw new InvalidDataException();
            }

            wavFile = array;
            int channels      = BitConverter.ToInt16(array, 22);
            int bitsPerSample = BitConverter.ToInt16(array, 34);
            int frequency     = BitConverter.ToInt32(array, 24);
            dataStartIndex    = BitConverter.ToInt32(array, 16) + 24;
            
            int dataSize = BitConverter.ToInt32(array, dataStartIndex);
            sampleSize = bitsPerSample / 8;
            int sampleCount = dataSize / sampleSize / 2;

            AudioClip audioClip = AudioClip.Create("Default", sampleCount, channels, frequency, true, OnAudioRead, i => position = i);
            return audioClip;
        }

        private static void OnAudioRead(float[] readData)
        {
            for (int i = 0; i < readData.Length; i++)
            {
                readData[i] = BitConverter.ToInt16(wavFile, dataStartIndex + 4 + position * sampleSize) / 32768.0f;
                position++;
            }
        }
    }
}