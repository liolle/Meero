using DotNetEnv;
using meero.bll.Service;
using meero.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(jwtOptions =>
{
	jwtOptions.Authority = configuration["JWT_ISSUER"];
	jwtOptions.Audience = configuration["JWT_AUDIENCE"];
    jwtOptions.RequireHttpsMetadata =false; // Allow HTTP in development
});

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("auth-input", policy=>{
        policy
        .WithOrigins(["http://localhost:3000","http://localhost"])
        .AllowCredentials()
        .WithHeaders(HeaderNames.ContentType, "Authorization")
        .WithMethods(["POST","OPTIONS"]);
    });
});

// BLL services
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

builder.Services.AddTransient<IPowerService,PowerService>();
builder.Services.AddTransient<IHeroService,HeroService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IHashService,HasherService>();
builder.Services.AddTransient<IAuthService,AuthService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

RouteConfig.RegisterRoutes(app);
app.Run();