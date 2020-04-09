using static UnityEngine.Application;

public class Assets : Singleton<Assets>
{
    public Skin Skin { get; private set; } 
    public Level Level { get; set; }
    public SavedSettings SavedSettings { get; set; }

    private void Awake()
    {
        SavedSettings = SavedSettingsLoader.Instance.Load(GenericPaths.SettingsPath);
        Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.SavedSettings.SkinName);
    }
}