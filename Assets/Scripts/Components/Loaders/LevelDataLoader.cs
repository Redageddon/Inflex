using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LevelDataLoader
{
    public static void SaveTest(string path)
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        var levels = levelPaths.Select(levelPath => new LevelData(LevelLoader.Load(levelPath)));

        using (var test = new Database<LevelData>("Levels", path))
        {
            test.Database.EnsureDeleted();
            if (test.Database.EnsureCreated())
            {
                test.Levels.AddRange(levels);
                test.SaveChanges();
            }
        }
    }
    public static List<LevelData> LoadTest(string path)
    {
        using (var test = new Database<LevelData>("Levels", path))
        {
            return test.Levels.ToList();
        }
    }
}