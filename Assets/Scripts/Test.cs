using Microsoft.EntityFrameworkCore;
using UnityEngine;

public class Test : DbContext
{
    public DbSet<LevelData> Levels { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={Application.streamingAssetsPath}/Levels.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LevelData>().ToTable("Levels").HasNoKey();
        base.OnModelCreating(modelBuilder);
    }
}