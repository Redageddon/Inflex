using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beatmaps;
using Database;

namespace Logic.Loaders
{
    public static class DatabaseLoader
    {
        public static void Save()
        {
            string[]          beatMapPaths = Directory.GetDirectories(GenericPaths.BeatMapsPath);
            IEnumerable<BeatMapData> beatMaps     = beatMapPaths.Select(path => new BeatMapData(FileLoader.LoadBeatMap(path)));

            using (InflexDatabase db = new InflexDatabase("BeatMaps", GenericPaths.BeatMapsDataPath))
            {
                db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated())
                {
                    db.BeatMaps.AddRange(beatMaps);
                    db.SaveChanges();
                }
            }
        }

        public static IEnumerable<BeatMapData> Load() => new InflexDatabase("BeatMaps", GenericPaths.BeatMapsDataPath).BeatMaps;

        public static void Remove(BeatMapData data)
        {
            using (InflexDatabase db = new InflexDatabase("BeatMaps", GenericPaths.BeatMapsDataPath))
            {
                db.BeatMaps.Remove(data);
                db.SaveChanges();
            }
        }
    }
}