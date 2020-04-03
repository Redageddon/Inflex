using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    private void Awake()
    {
        CheckNotDefaultSkin();
        LoadSettings();
    }

    private void LoadSettings()
    {
        SettingsHandler.Instance.SavedSettings = SettingsHandler.Instance.Load(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
    }

    private void CheckNotDefaultSkin()
    {
        if (SettingsHandler.Instance.SavedSettings.SkinName != "Default")
        {
            var skinPath = Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Skins\" + SettingsHandler.Instance.SavedSettings.SkinName);
        }
    }
}