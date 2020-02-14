using System.Linq;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class JsonLoader
{
    public static Map LoadMap(string path)
    {
        var json = Directory.GetFiles(path, @"*.json").First();
        var data = File.ReadAllText(json);
        Map currentMap = JsonConvert.DeserializeObject<Map>(data);
        currentMap.Path = path;
        return currentMap;
    }

    public static SavedSettings LoadSettings()
    {
        
        string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
        SavedSettings settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public static void SaveSettings(SavedSettings settings)
    {
        string json = JsonConvert.SerializeObject(settings, (Formatting) 1);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"), json);
    }
}