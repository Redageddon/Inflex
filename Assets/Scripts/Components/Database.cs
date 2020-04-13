using Microsoft.EntityFrameworkCore;

public class Database<T> : DbContext where T : class
{
    public Database()
    {
    }
    
    public Database(string tableName, string dbPath)
    {
        this.tableName = tableName;
        this.dbPath = dbPath;
    }
    
    public DbSet<T> Levels { get; set; }
    private readonly string tableName;
    private readonly string dbPath;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<T>().ToTable(tableName);
        base.OnModelCreating(modelBuilder);
    }
    
}