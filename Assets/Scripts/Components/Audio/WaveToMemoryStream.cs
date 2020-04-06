using System.IO;
using NAudio.Wave;

public class WaveToMemoryStream
{
    public readonly MemoryStream Stream;
    public WaveToMemoryStream(WaveStream waveStream)
    {
        var outputStream = new MemoryStream();
        using (var waveFileWriter = new WaveFileWriter(outputStream, waveStream.WaveFormat))
        {
            var bytes = new byte[waveStream.Length];
            waveStream.Read(bytes, 0, (int) waveStream.Length);
            waveFileWriter.Write(bytes, 0, bytes.Length);
            waveFileWriter.Flush();
        }

        Stream = outputStream;
    }
}