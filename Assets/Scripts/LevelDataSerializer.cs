using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LevelDataSerializer : Singleton<LevelDataSerializer>
{
    private readonly string path = Application.streamingAssetsPath + "/Levels.bin";
    public List<LevelData> GetAllLevels()
    {
        if (!File.Exists(path)) return null;
        
        using (var stream = File.Open(path, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (List<LevelData>)binaryFormatter.Deserialize(stream);
        }
    }

    public void RefreshAllLevels()
    {
        var levelPaths = Directory.GetDirectories(Environment.ExpandEnvironmentVariables(@"%AppData%\Inflex\Maps\"));
        
        var levels = levelPaths.Select(MapHandler.Instance.Load).Select(x => new LevelData(x.Title, x.Path, x.Icon, 0)).ToList();

        using (var stream = File.Create(path))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, levels);
        }
    }
}