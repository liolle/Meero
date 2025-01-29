using meero.entity;
using Microsoft.EntityFrameworkCore;

namespace meero.Database;
public interface IDataContext 
{
    public DbSet<UserEntity> Users {get;set;}
    public DbSet<HeroEntity> Heroes {get;set;}
    public DbSet<PowerEntity> Powers {get;set;}
    public DbSet<LocationEntity> Locations {get;set;}

    int SaveChanges();
}