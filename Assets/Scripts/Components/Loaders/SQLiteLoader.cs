using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LevelDataLoader
{
    public static void Save()
    {
        var levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        var levels = levelPaths.Select(levelPath => new LevelData(JsonLoader.LoadLevel(levelPath)));

        using (var db = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
        {
            db.Database.EnsureDeleted();
            if (db.Database.EnsureCreated())
            {
                db.Levels.AddRange(levels);
                db.SaveChanges();
            }
        }
    }
    
    public static IEnumerable<LevelData> Load() => new Database<LevelData>("Levels", GenericPaths.LevelsDataPath).Levels;
}