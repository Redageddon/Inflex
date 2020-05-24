using System.Collections.Generic;
using System.IO;
using System.Linq;
using Components;
using Database;

namespace Logic.Loaders
{
    public static class DatabaseLoader
    {
        public static void Save()
        {
            string[] beatMapPaths = Directory.GetDirectories(GenericPaths.BeatMapsPath);
            List<BeatMapData> beatMaps = beatMapPaths.Select(path => new BeatMapData(FileLoader.LoadBeatMap(path))).ToList();

            using (Database<BeatMapData> db = new Database<BeatMapData>("BeatMaps", GenericPaths.BeatMapsDataPath))
            {
                db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated())
                {
                    db.BeatMaps.AddRange(beatMaps);
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<BeatMapData> Load() => new Database<BeatMapData>("BeatMaps", GenericPaths.BeatMapsDataPath).BeatMaps;
    }
}