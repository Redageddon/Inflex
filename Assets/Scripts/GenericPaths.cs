using System;
using UnityEngine;

public static class GenericPaths
{
    public static string InflexPath => Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\");
    public static string LevelsPath => Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Levels\");
    public static string SkinsPath => Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Skins\");
    public static string LevelsDataPath => Application.streamingAssetsPath + @"\Levels.bin";
    public static string SettingsPath => Application.streamingAssetsPath + @"\Settings.json";
}