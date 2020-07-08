using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beatmaps;
using Logic.Loaders;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class InflexContext : DbContext
    {
        private static readonly InflexContext Context = new InflexContext();

        private DbSet<BeatMapData> BeatMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={GenericPaths.BeatMapsDataPath}");
        
        public static void Save()
        {
            Directory.CreateDirectory(GenericPaths.BeatMapsPath);
            string[]                 beatMapPaths = Directory.GetDirectories(GenericPaths.BeatMapsPath);
            IEnumerable<BeatMapData> beatMaps     = beatMapPaths.Select(path => new BeatMapData(FileLoader.LoadBeatMap(path)));
            
            Context.Database.EnsureCreated();
            Context.Database.ExecuteSqlRaw("delete from BeatMaps");
            Context.AddRange(beatMaps);
            Context.SaveChanges();
        }

        public static IEnumerable<BeatMapData> Load()
        {
            if (!File.Exists(GenericPaths.BeatMapsDataPath))
            {
                Save();
            }

            return Context.BeatMaps;
        }

        public static void RemoveMap(BeatMapData data)
        {
            Context.Remove(data);
            Context.SaveChanges();
        }
    }
}