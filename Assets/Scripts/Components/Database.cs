using Microsoft.EntityFrameworkCore;

public class Database<T> : DbContext where T : class
{
    public DbSet<LevelData> Levels { get; set; }
    private readonly string tableName;
    private readonly string dbPath;

    public Database(string tableName, string dbPath)
    {
        this.tableName = tableName;
        this.dbPath = dbPath;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={dbPath}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T>().ToTable(tableName);
        base.OnModelCreating(modelBuilder);
    }
    
}