using System.Collections.Generic;
using System.IO;
using System.Linq;
using Beatmaps;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class InflexContext : DbContext
    {
        private static readonly InflexContext Context = new InflexContext();

        private DbSet<BeatMapMetadata> BeatMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={GenericPaths.BeatMapsDataPath}");

        public static void Save()
        {
            Directory.CreateDirectory(GenericPaths.BeatMapsPath);
            var beatMapPaths = Directory.GetDirectories(GenericPaths.BeatMapsPath);
            var beatMaps     = beatMapPaths.Select(FileLoader.LoadBeatMap);
            Context.Database.EnsureCreated();
            Context.Database.ExecuteSqlRaw("delete from BeatMaps");

            Context.AddRange(beatMaps);
            Context.SaveChanges();
        }

        public static IEnumerable<BeatMapMetadata> Load()
        {
            if (!File.Exists(GenericPaths.BeatMapsDataPath))
            {
                Save();
            }

            return Context.BeatMaps;
        }

        public static void RemoveMap(BeatMapMetadata metadata)
        {
            Context.Remove(metadata);
            Context.SaveChanges();
        }
    }
}