using System;
using UnityEngine;

public static class GenericPaths
{
    public static string InflexPath { get; } = Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\");
    public static string LevelsPath { get; } = Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Levels\");
    public static string SkinsPath { get; } = Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Skins\");
    public static string LevelsDataPath { get; } = Application.streamingAssetsPath + "/Levels.bin";
    public static string SettingsPath { get; } = Application.streamingAssetsPath + "Settings.json";
}