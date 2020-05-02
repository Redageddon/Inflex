using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class LevelDataLoader
{
    public static void Save()
    {
        string[] levelPaths = Directory.GetDirectories(GenericPaths.LevelsPath);
        List<LevelData> levels = levelPaths.Select(path => new LevelData(Loader.LoadLevel(path))).ToList();

        using (Database<LevelData> db = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
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