using System.IO;
using Inflex.Rron;
using static UnityEngine.Application;

public class Assets : Singleton<Assets>
{
    public Level Level { get; set; }
    public Skin Skin { get; private set; }
    public SavedSettings Settings { get; } = LoadSettings();

    private static SavedSettings LoadSettings()
    {
        if (File.Exists(GenericPaths.SettingsPath))
        {
            return RronConvert.DeserializeObjectFromFile<SavedSettings>(GenericPaths.SettingsPath);
        }
        SavedSettings settings = new SavedSettings("Default");
        RronConvert.SerializeObjectToFile(settings, GenericPaths.SettingsPath);
        return settings;
    }

    private void Awake()
    {
        Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.Settings.SkinName);
    }
}