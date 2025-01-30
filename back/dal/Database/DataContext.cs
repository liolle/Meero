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
    public DbSet<HeroEntity> Heroes {get;set;}
    public DbSet<PowerEntity> Powers {get;set;}
    public DbSet<LocationEntity> Locations {get;set;}
     public DbSet<EventEntity> Events {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new HeroConfig());
        modelBuilder.ApplyConfiguration(new LocationConfig());
        modelBuilder.ApplyConfiguration(new PowerConfig());
        modelBuilder.ApplyConfiguration(new EventConfig());
    }
}