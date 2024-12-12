using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MusicFestivalManagement.Repository.Interfaces;
using MusicFestivalManagement.Repository;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Helpers;
using MusicFestivalManagement.Settings;
using MusicFestivalManagement.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Ρυθμίσεις για DbContext
builder.Services.AddDbContext<FestivalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ρυθμίσεις JWT
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection(JWTSettings.JWT));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = MusicFestivalManagement.Helpers.ConfigurationManager.AppSetting["JWTSettings:ValidIssuer"],
        ValidAudience = MusicFestivalManagement.Helpers.ConfigurationManager.AppSetting["JWTSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MusicFestivalManagement.Helpers.ConfigurationManager.AppSetting["JWTSettings:Secret"])),
        ClockSkew = TimeSpan.Zero
    };
});

// Dependency Injection για Repositories & Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IFestivalRepository, FestivalRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<PerformanceService>();
builder.Services.AddScoped<FestivalService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Προσθήκη Swagger με Authorize
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Festival API", Version = "v1" });

    // Ρύθμιση του Security Schema
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Παρακαλώ εισάγετε το JWT Token στο πεδίο 'Authorization' ως εξής: Bearer {your token}"
    });

    // Εφαρμογή του Security Scheme σε όλα τα endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ενεργοποίηση Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
