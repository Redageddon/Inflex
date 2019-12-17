using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PathData : MonoBehaviour
{
    private static string MainPath { get; } = @"%AppData%\CircleRhythm\Maps\";
    public static string[] MapNames = Directory.GetDirectories(Environment.ExpandEnvironmentVariables(MainPath));
    protected static string FileName { get; set; }
    void Start()
    {
    }
}