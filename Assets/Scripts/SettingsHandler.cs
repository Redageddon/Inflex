using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class SettingsHandler
{
    public static SavedSettings LoadSettings()
    {
        var json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
        var settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public static void SaveSettings(SavedSettings settings)
    {
        var json = JsonConvert.SerializeObject(settings, (Formatting) 1);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"), json);
    }
}