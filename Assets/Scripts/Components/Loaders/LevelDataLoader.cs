using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Components.Loaders
{
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

        public static IEnumerable<LevelData> Load()
        {
            using (Database<LevelData> data = new Database<LevelData>("Levels", GenericPaths.LevelsDataPath))
            {
                return data.Levels;
            }
        }
    }
}