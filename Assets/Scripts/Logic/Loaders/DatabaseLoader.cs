using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beatmaps;
using Database;
using Microsoft.EntityFrameworkCore.Internal;

namespace Logic.Loaders
{
    public static class DatabaseLoader
    {
        public static void Save()
        {
            string[]                 beatMapPaths = Directory.GetDirectories(GenericPaths.BeatMapsPath);
            IEnumerable<BeatMapData> beatMaps     = beatMapPaths.Select(path => new BeatMapData(FileLoader.LoadBeatMap(path)));

            using (InflexDatabase database = new InflexDatabase())
            {
                database.Database.EnsureDeleted();
                if (database.Database.EnsureCreated())
                {
                    database.BeatMaps.AddRange(beatMaps);
                    database.SaveChanges();
                }
            }
        }

        public static IEnumerable<BeatMapData> Load() => new InflexDatabase().BeatMaps;

        public static void Remove(BeatMapData data)
        {
            using (InflexDatabase db = new InflexDatabase())
            {
                db.BeatMaps.Remove(data);
                db.SaveChanges();
            }
        }
    }
}