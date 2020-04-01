using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class LevelDataSerializer
{
    private static readonly string Path = Application.streamingAssetsPath + "/Levels.ds";
    public static List<LevelData> GetAllLevelsData()
    {
        if (!File.Exists(Path)) return null;
        using (var fs = File.OpenRead(Path))
        using (var cs = new DeflateStream(fs, CompressionMode.Decompress))
        using (var streamReader = new StreamReader(cs))
        {
            return JsonConvert.DeserializeObject<List<LevelData>>(streamReader.ReadToEnd());
        }
    }

    public static void RefreshAllLevelsData()
    {
        var levelPaths = Directory.GetDirectories(Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Maps\"));
        
        var levels = levelPaths.Select(MapHandler.LoadMap).Select(x => new LevelData(x.Title, x.Path, x.Icon, 0)).ToList();
        
        using (var fs = File.Create(Path))
        using (var cs = new DeflateStream(fs, System.IO.Compression.CompressionLevel.Fastest))
        using (var writer = new StreamWriter(cs))
        {
            writer.Write(JsonConvert.SerializeObject(levels));
        }
    }
}