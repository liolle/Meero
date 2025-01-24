using DotNetEnv;
using meero.bll.Service;
using meero.Database;
using meero.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Env.Load();

// Modify config variable that will be injected by Services.AddSingleton<IConfiguration>(configuration)
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddSingleton<IConfiguration>(configuration);

// Database service 
builder.Services.AddScoped<IDataContext,DataContext>( 
    s=> {
        string? connectionString = configuration["DB_CONNECTION_STRING"];
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(connectionString, "Connection string is missing or empty.");
        }

        DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connectionString).Options;
        return new DataContext(options);
    }
);

builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

builder.Services.AddTransient<IHashService,HasherService>();
builder.Services.AddTransient<IAuthService,AuthService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

RouteConfig.RegisterRoutes(app);
app.Run();