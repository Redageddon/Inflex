using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Application;

public class Assets : Singleton<Assets>
{
    public Skin Skin { get; set; } = new Skin();
    public Level Level { get; set; }
    public SavedSettings SavedSettings { get; set; }

    private void Awake()
    {
        LoadSettings();
        LoadSkin();
    }

    private void LoadSettings()
    {
        SavedSettings = SavedSettingsLoader.Instance.Load(GenericPaths.SettingsPath);
    }

    private void LoadSkin()
    {
        var skinName = Instance.SavedSettings.SkinName;
        if (skinName == "Default") return;
        Skin.BackButton = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/BackButton.png");
        Skin.Background = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/Background.png");
        Skin.Center = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/Center.png");
        Skin.CurrentKeys = new List<Texture2D>
        {
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/CurrentKey1.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/CurrentKey2.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/CurrentKey3.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/CurrentKey4.png")
        };
        Skin.HitObjects = new List<Texture2D>
        {
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/HitObject1.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/HitObject2.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/HitObject3.png"),
            Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/HitObject4.png")
        };
        Skin.LevelButton = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/LevelButton.png");
        Skin.PauseButton = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/PauseButton.png");
        Skin.Pointer = Texture2DLoader.Instance.Load(streamingAssetsPath + $"/Skins/{skinName}/Pointer.png");
    }
}