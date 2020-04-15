using System.IO;
using static UnityEngine.Application;

public class Assets : Singleton<Assets>
{
    public Level Level { get; set; }
    public Skin Skin { get; private set; }
    public SavedSettings Settings { get; } = LoadSettings();

    private static SavedSettings LoadSettings()
    {
        return File.Exists(GenericPaths.SettingsPath + "Test")
            ? JsonLoader.Load<SavedSettings>(GenericPaths.SettingsPath + "Test")
            : new SavedSettings();
    }
    
    private void Awake()
    {
        Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.Settings.SkinName);
    }
}