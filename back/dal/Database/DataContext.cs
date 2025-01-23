using entity.fluent;
using meero.entity;
using Microsoft.EntityFrameworkCore;

namespace meero.Database;

class DataContext : DbContext, IDataContext
{
    public DbSet<UserEntity> Users {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}