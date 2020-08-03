using static UnityEngine.Application;

public static class GenericPaths
{
    public static string SkinsPath        => streamingAssetsPath + "/Skins/";
    public static string BeatMapsPath     => streamingAssetsPath + "/BeatMaps/";
    public static string BeatMapsDataPath => streamingAssetsPath + "/BeatMaps.db";
    public static string SettingsPath     => streamingAssetsPath + "/Settings.rron";
}