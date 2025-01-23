using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace meero.Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {

        Env.Load();

        IConfiguration config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        string? connectionString = config["DB_CONNECTION_STRING"];

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(connectionString, "Connection string is missing or empty.");
        }


        var optionsBuilder  = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, 
                maxRetryDelay: TimeSpan.FromSeconds(30), 
                errorNumbersToAdd: null); 
        });

        return new DataContext(optionsBuilder.Options);
    }
}