using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class JsonLoader
{
    public static Map LoadMap(string path)
    {
        var json = Directory.GetFiles(path, @"*.json").First();
        var data = File.ReadAllText(json);
        var currentMap = JsonConvert.DeserializeObject<Map>(data);
        currentMap.Path = path;
        return currentMap;
    }

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