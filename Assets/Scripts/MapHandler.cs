using System.IO;
using System.Linq;
using Newtonsoft.Json;

public static class MapHandler
{
    public static Map LoadMap(string path)
    {
        var json = Directory.GetFiles(path, @"*.json").First();
        var data = File.ReadAllText(json);
        var currentMap = JsonConvert.DeserializeObject<Map>(data);
        currentMap.Path = path;
        return currentMap;
    }

    public static void SaveMap(string path, Map map)
    {
        var json = JsonConvert.SerializeObject(map, (Formatting) 1);
        File.WriteAllText(path, json);
    }
}