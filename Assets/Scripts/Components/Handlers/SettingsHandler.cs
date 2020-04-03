using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SettingsHandler : Singleton<SettingsHandler>, IHandlerBase<SavedSettings>
{
    public SavedSettings SavedSettings { get; set; }

    public SavedSettings Load(string path)
    {
        var json = File.ReadAllText(path);
        var settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public void Save(string path)
    {
        var json = JsonConvert.SerializeObject(SavedSettings, (Formatting) 1);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"), json);
    }
}