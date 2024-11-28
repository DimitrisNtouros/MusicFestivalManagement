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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FestivalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IFestivalRepository, FestivalRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<PerformanceService>();
builder.Services.AddScoped<FestivalService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
