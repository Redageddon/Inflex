using System.IO;
using System.Linq;
using Newtonsoft.Json;

public static class MapHandler
{
    public static Map Map;
    
    public static Map LoadMap(string path)
    {
        var json = Directory.GetFiles(path, @"*.json").First();
        var data = File.ReadAllText(json);
        var dataWithPath = "{\n" + @"""Path"":""" + path.Replace(@"\", @"\\") + @"""," + data.Remove(0, 1);
        var currentMap = JsonConvert.DeserializeObject<Map>(dataWithPath);
        return currentMap;
    }

    public static void UpdatePublicMap(string path)
    {
        Map = LoadMap(path);
    }

    public static void SaveMap(string path, Map map)
    {
        var json = JsonConvert.SerializeObject(map, (Formatting) 1);
        File.WriteAllText(path, json);
    }
}