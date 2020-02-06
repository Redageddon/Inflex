using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonLoader : MonoBehaviour
{
    private static string _path;

    public static Map LoadMap(string path)
    {
        _path = Directory.GetFiles(path, @"*.json").First();
        string json = File.ReadAllText(_path);
        Map currentMap = JsonConvert.DeserializeObject<Map>(json);
        currentMap.Path = path;
        return currentMap;
    }

    public static SavedSettings LoadSettings()
    {
        string json = File.ReadAllText("Assets/Settings.json");
        SavedSettings settings = JsonConvert.DeserializeObject<SavedSettings>(json);
        return settings;
    }

    public static void SaveSettings(SavedSettings settings)
    {
        string json = JsonConvert.SerializeObject(settings, (Formatting) 1);
        File.WriteAllText("Assets/Settings.json", json);
    }

}