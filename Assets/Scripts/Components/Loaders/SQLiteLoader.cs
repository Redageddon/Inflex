using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LevelDataLoader
{
    public static void Save()
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        var levels = levelPaths.Select(levelPath => new LevelData(JsonLoader.LoadLevel(levelPath)));

        using (var test = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            test.Database.EnsureDeleted();
            if (test.Database.EnsureCreated())
            {
                test.Levels.AddRange(levels);
                test.SaveChanges();
            }
        }
    }
    
    public static IEnumerable<LevelData> Load() => new Database<LevelData>("Levels", GenericPaths.LevelsDataPath).Levels;
}