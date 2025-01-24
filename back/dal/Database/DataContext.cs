using entity.fluent;
using meero.entity;
using Microsoft.EntityFrameworkCore;

namespace meero.Database;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<UserEntity> Users {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}