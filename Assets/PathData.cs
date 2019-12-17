using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private static string MainPath { get; } = @"%AppData%\CircleRhythm\Maps\";
    protected static string MapName { get; set; }
    protected static string FileName { get; set; }
    string FullPath { get; set; } = MainPath + MapName + FileName;
}
