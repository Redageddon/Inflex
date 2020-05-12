using Microsoft.EntityFrameworkCore;

public class Database<T> : DbContext
    where T : class
{
    private readonly string dbPath;
    private readonly string tableName;

    public Database(string tableName, string dbPath)
    {
        this.tableName = tableName;
        this.dbPath = dbPath;
    }

    public DbSet<LevelData> Levels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={this.dbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T>().ToTable(this.tableName);
        base.OnModelCreating(modelBuilder);
    }
}