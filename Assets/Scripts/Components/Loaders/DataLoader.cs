using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DataLoader : Singleton<DataLoader>, ILoader<List<LevelData>>
{
    public List<LevelData> Load(string path)
    {
        using (var stream = File.Open(path, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (List<LevelData>)binaryFormatter.Deserialize(stream);
        }
    }

    public void Save(string path)
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        List<LevelData> levels = levelPaths.Select(levelPath => new LevelData(LevelLoader.Instance.Load(levelPath))).ToList();

        using (var stream = File.Create(path))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, levels);
        }
    }
}