using System.IO;
using Beatmaps;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class InflexDatabase : DbContext
    {
        public InflexDatabase() => Directory.CreateDirectory(Path.GetDirectoryName(GenericPaths.BeatMapsDataPath));

        public DbSet<BeatMapData> BeatMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={GenericPaths.BeatMapsDataPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeatMapData>().ToTable("BeatMaps");
            base.OnModelCreating(modelBuilder);
        }
    }
}