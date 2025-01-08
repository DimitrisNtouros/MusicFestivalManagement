using System.Data;
using Microsoft.EntityFrameworkCore;

namespace MusicFestivalManagement.Models;

public class FestivalContext : DbContext
{
    public FestivalContext(DbContextOptions<FestivalContext> options) : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Festival> Festivals { get; set; }
    public virtual DbSet<Performance> Performances { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MusicFestival2;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");
            entity.HasKey(ur => ur.UserRoleId);

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            entity.HasOne(ur => ur.Festival)
                .WithMany(f => f.UserRoles)
                .HasForeignKey(ur => ur.FestivalId);

            entity.HasIndex(ur => new { ur.UserId, ur.FestivalId }).IsUnique();
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");
            entity.HasKey(a => a.ArtistId);

            entity.Property(a => a.Name)
                .HasMaxLength(100);

            entity.Property(a => a.Role)
                .HasMaxLength(50);

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(x => x.UserId);

            entity.Property(x => x.Firstname).HasMaxLength(50);
            entity.Property(x => x.Lastname).HasMaxLength(50);
            entity.Property(x => x.Username).HasMaxLength(20);
            entity.Property(x => x.Email).HasMaxLength(100);
            entity.Property(x => x.PasswordHash).HasMaxLength(255);
            entity.Property(x => x.PhoneNumber).HasMaxLength(20);
            entity.Property(x => x.Salt);
            entity.Property(x => x.CreatedAt);
            entity.Property(x => x.UpdatedAt);


        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
            entity.HasKey(r => r.RoleId);

        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.ToTable("Performance");
            entity.HasKey(p => p.PerformanceId); 

            entity.Property(p => p.Name)
                .HasMaxLength(100); 

            entity.Property(p => p.Description)
                .HasMaxLength(500); 

            entity.Property(p => p.Genre)
                .HasMaxLength(50); 

            entity.Property(p => p.Duration);

            entity.Property(p => p.CreationDate);

            entity.Property(p => p.State)
                .HasMaxLength(50); 

            entity.HasOne(p => p.Festival) 
                .WithMany(f => f.Performances) 
                .HasForeignKey(p => p.FestivalId);

            entity.Property(p => p.TechnicalRequirements)
                .HasMaxLength(500); 

            entity.Property(p => p.Setlist)
                .HasMaxLength(1000); 

            entity.Property(p => p.MerchandiseItems)
                .HasMaxLength(1000); 

            entity.Property(p => p.PreferredRehearsalTimes)
                .HasMaxLength(1000); 

            entity.Property(p => p.PreferredPerformanceSlots)
                .HasMaxLength(1000); 
        });

        modelBuilder.Entity<Festival>(entity =>
        {
            entity.ToTable("Festival");
            entity.HasKey(f => f.FestivalId);

            entity.Property(f => f.Name)
                .HasMaxLength(100);

            entity.Property(f => f.Description)
                .HasMaxLength(500);

            entity.Property(f => f.Venue)
                .HasMaxLength(200);

            entity.Property(f => f.State)
                .HasMaxLength(50);

            entity.HasMany(f => f.Performances)
                .WithOne(p => p.Festival)
                .HasForeignKey(p => p.FestivalId);
        });
    }
}