using System.IO;
using UnityEngine;

public class PathData : MonoBehaviour
{
    private static readonly string MainPath = @"%AppData%\CircleRhythm\Maps\";
    public static readonly string[] MapNames = Directory.GetDirectories(System.Environment.ExpandEnvironmentVariables(MainPath));
}