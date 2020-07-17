using System;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;
using SearchAlgorithms;
using UnityEngine;
using SearchAlgorithms.Algorithms;
using Debug = UnityEngine.Debug;

namespace Audio
{
    public static class Mp3ToAudioClip
    {
        private static int position;
        private static byte[] wavFile;
        private static int dataIndex;
        private static int sampleSize;

        public static AudioClip FromMp3Bytes(byte[] bytes)
        {
            MemoryStream mp3Stream = new MemoryStream(bytes);
            using (Mp3FileReader mp3Audio = new Mp3FileReader(mp3Stream))
            {
                using (WaveStream waveStream = WaveFormatConversionStream.CreatePcmStream(mp3Audio))
                {
                    return ByteArrayToAudioClip(WaveToMemoryStream(waveStream).ToArray());
                }
            }
        }

        private static MemoryStream WaveToMemoryStream(WaveStream waveStream)
        {
            MemoryStream outputStream = new MemoryStream();
            using (WaveFileWriter waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
            {
                byte[] bytes = new byte[waveStream.Length];
                waveStream.Read(bytes, 0, (int)waveStream.Length);
                waveFileWriter.Write(bytes, 0, bytes.Length);
                waveFileWriter.Flush();

                return outputStream;
            }
        }

        private static AudioClip ByteArrayToAudioClip(byte[] array)
        {
            if (BitConverter.ToInt16(array, 20) != 1)
            {
                throw new InvalidDataException();
            }

            wavFile = array;
            int numChannels = BitConverter.ToInt16(array, 22);
            int bitsPerSample = BitConverter.ToInt16(array, 34);
            int sampleRate = BitConverter.ToInt32(array, 24);
            dataIndex = BitConverter.ToInt32(array, 16) + 20;
            
            dataIndex = wavFile.SingleSearch(new[] {(byte)'d', (byte)'a', (byte)'t',(byte)'a'}, new Rubikmaster02());

            int subChunk2Size = BitConverter.ToInt32(array, dataIndex);
            sampleSize = bitsPerSample / 8;
            int sampleCount = subChunk2Size / sampleSize;

            AudioClip audioClip = AudioClip.Create("Default", sampleCount, numChannels, sampleRate, true, OnAudioRead,i=> position = i );
            
            return audioClip;
        }

        private static void OnAudioRead(float[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = BitConverter.ToInt16(wavFile, dataIndex + 4 + position * sampleSize) / 32768.0f;
                position++;
            }
        }
    }
}