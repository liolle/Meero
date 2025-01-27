using meero.entity;
using Microsoft.EntityFrameworkCore;

namespace meero.Database;
public interface IDataContext 
{

    DbSet<UserEntity> Users {get;set;}

    public DbSet<HeroEntity> Heroes {get;set;}
    public DbSet<PowerEntity> Powers {get;set;}

    int SaveChanges();
}
