using System;
using System.IO;
using Beatmaps;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class InflexDatabase : DbContext
    {
        private readonly string dbPath;
        private readonly string tableName;

        public InflexDatabase(string tableName, string dbPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            this.tableName = tableName;
            this.dbPath = dbPath;
        }

        public DbSet<BeatMapData> BeatMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={this.dbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeatMapData>().ToTable(this.tableName);
            base.OnModelCreating(modelBuilder);
        }
    }
}