using static UnityEngine.Application;

public static class GenericPaths
{
    public static string SkinsPath => streamingAssetsPath + @"\Skins\";
    public static string LevelsPath => streamingAssetsPath + @"\Levels\";
    public static string LevelsDataPath => streamingAssetsPath + @"\Levels.bin";
    public static string SettingsPath => streamingAssetsPath + @"\Settings.json";
}