using UnityEngine;

public class Wav
{
    // convert two bytes to one float in the range -1 to 1
    private static float BytesToFloat(byte firstByte, byte secondByte)
    {
        // convert two bytes to one short (little endian)
        var s = (short) ((secondByte << 8) | firstByte);
        // convert to range from -1 to (just below) 1
        return s / 32768.0F;
    }

    private static int BytesToInt(byte[] bytes, int offset = 0)
    {
        var value = 0;
        for (var i = 0; i < 4; i++)
        {
            value |= bytes[offset + i] << (i * 8);
        }

        return value;
    }

    // properties
    internal float[] LeftChannel { get; }
    private float[] RightChannel { get; }
    internal float[] StereoChannel { get; }
    internal int ChannelCount { get; }
    internal int SampleCount { get; }
    internal int Frequency { get; }

    public Wav(byte[] wav)
    {
        // Determine if mono or stereo
        ChannelCount = wav[22]; // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

        // Get the frequency
        Frequency = BytesToInt(wav, 24);

        // Get past all the other sub chunks to get to the data subchunk:
        var pos = 12; // First Subchunk ID from 12 to 16

        // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
        while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
        {
            pos += 4;
            int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
            pos += 4 + chunkSize;
        }

        pos += 8;

        // Pos is now positioned to start of actual sound data.
        SampleCount = (wav.Length - pos) / 2; // 2 bytes per sample (16 bit sound mono)
        if (ChannelCount == 2) SampleCount /= 2; // 4 bytes per sample (16 bit stereo)

        // Allocate memory (right will be null if only mono sound)
        LeftChannel = new float[SampleCount];
        RightChannel = ChannelCount == 2 ? new float[SampleCount] : null;

        // Write to double array/s:
        var i = 0;
        while (pos < wav.Length)
        {
            LeftChannel[i] = BytesToFloat(wav[pos], wav[pos + 1]);
            pos += 2;
            if (ChannelCount == 2)
            {
                RightChannel[i] = BytesToFloat(wav[pos], wav[pos + 1]);
                pos += 2;
            }

            i++;
        }

        //Merge left and right channels for stereo sound
        if (ChannelCount == 2)
        {
            StereoChannel = new float[SampleCount * 2];
            //Current position in our left and right channels
            var channelPos = 0;
            //After we've changed two values for our Stereochannel, we want to increase our channelPos
            short posChange = 0;

            for (var index = 0; index < (SampleCount * 2); index++)
            {
                if (index % 2 == 0)
                {
                    StereoChannel[index] = LeftChannel[channelPos];
                    posChange++;
                }
                else
                {
                    StereoChannel[index] = RightChannel[channelPos];
                    posChange++;
                }

                //Two values have been changed, so update our channelPos
                if (posChange % 2 != 0) continue;
                if (channelPos >= SampleCount) continue;
                channelPos++;
                //Reset the counter for next iterations
                posChange = 0;
            }
        }
        else
        {
            StereoChannel = null;
        }
    }

    public override string ToString()
    {
        return string.Format($"[WAV: LeftChannel={LeftChannel}, RightChannel={RightChannel}, ChannelCount={ChannelCount}, SampleCount={SampleCount}, Frequency={ Frequency}]");
    }
}