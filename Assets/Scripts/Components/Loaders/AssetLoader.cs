using System;
using UnityEngine;

public class AssetLoader : Singleton<AssetLoader>
{
    public Skin Skin { get; set; }
    public Level Level { get; set; }
    public SavedSettings SavedSettings { get; set; }
    
    private void Awake()
    {
        Load();
        CheckNotDefaultSkin();
    }

    private void Load()
    {
        SavedSettings = SavedSettingsLoader.Instance.Load(GenericPaths.SettingsPath);
    }

    private void CheckNotDefaultSkin()
    {
        if (Instance.SavedSettings.SkinName != "Default")
        {
            var skinPath = GenericPaths.SkinsPath + Instance.SavedSettings.SkinName;
        }
    }
    
    public void Save(string path = "")
    {
        Debug.LogWarning("This has not been Implemented");
        throw new NotImplementedException();
    }
}