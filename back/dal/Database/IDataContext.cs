using meero.entity;
using Microsoft.EntityFrameworkCore;

namespace meero.Database;
public interface IDataContext 
{

    DbSet<UserEntity> Users {get;set;}

    int SaveChanges();
}
