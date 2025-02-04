using System.Text;
using DotNetEnv;
using meero.bll.Service;
using meero.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT_ISSUER"],
            ValidAudience = builder.Configuration["JWT_AUDIENCE"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT_KEY"]))
        };

        // ✅ Extract JWT from Cookie instead of Authorization header
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                string AUTH_TOKEN_NAME = builder.Configuration["AUTH_TOKEN_NAME"];
                if (context.Request.Cookies.ContainsKey(AUTH_TOKEN_NAME))
                {
                    context.Token = context.Request.Cookies[AUTH_TOKEN_NAME];
                }
                return Task.CompletedTask;
            }
        };
    });

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("auth-input", policy=>{
        policy
        .WithOrigins(["http://localhost:3000","http://localhost"])
        .AllowCredentials()
        .WithHeaders(Microsoft.Net.Http.Headers.HeaderNames.ContentType, "Authorization")
        .WithMethods(["POST","OPTIONS"]);
    });
});

// BLL services
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

builder.Services.AddTransient<ILocationService,LocationService>();
builder.Services.AddTransient<IPowerService,PowerService>();
builder.Services.AddTransient<IHeroService,HeroService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IHashService,HasherService>();
builder.Services.AddTransient<IAuthService,AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

RouteConfig.RegisterRoutes(app);
app.Run();