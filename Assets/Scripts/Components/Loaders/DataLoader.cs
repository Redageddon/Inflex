using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DataLoader : Singleton<DataLoader>, ILoader<List<Data>>
{
    public List<Data> Load(string path)
    {
        using (var stream = File.Open(path, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (List<Data>)binaryFormatter.Deserialize(stream);
        }
    }

    public void Save(string path)
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        var levels = levelPaths.Select(LevelLoader.Instance.Load).Select(x => new Data(x.Title, x.Path, x.Icon, 0, x.SongFile)).ToList();

        using (var stream = File.Create(path))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, levels);
        }
    }
}