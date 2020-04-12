using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class DataLoader
{
    public static List<LevelData> Load(string path)
    {
        using (var stream = File.Open(path, FileMode.Open))
        {
            var binaryFormatter = new BinaryFormatter();
            return (List<LevelData>) binaryFormatter.Deserialize(stream);
        }
    }

    public static void Save(string path)
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        List<LevelData> levels = levelPaths.Select(levelPath => new LevelData(LevelLoader.Load(levelPath))).ToList();

        using (var stream = File.Create(path))
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, levels);
        }
    }

    public static void DbTest()
    {
        using (Test test = new Test())
        {
            if (test.Database.EnsureCreated())
            {
                test.Levels.Add(
                    new LevelData
                    {
                        Title = "TestTitle",
                        Path = "TestPath",
                        Icon = "TestIcon",
                        Difficulty = 0,
                        SongFile = "TestSongFile"
                    });
                test.SaveChanges();
            }
        }
    }
}