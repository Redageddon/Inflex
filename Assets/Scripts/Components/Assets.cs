using static UnityEngine.Application;

public class Assets : Singleton<Assets>
{
    public Level Level { get; set; }
    public Skin Skin { get; private set; }
    public SavedSettings SavedSettings { get; set; } = JsonLoader.Load<SavedSettings>(GenericPaths.SettingsPath);

    private void Awake()
    {
        Skin = new Skin(streamingAssetsPath + "/Skins/", Instance.SavedSettings.SkinName);
    }
}