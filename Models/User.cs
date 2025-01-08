using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MusicFestivalManagement.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Column("Salt")]
    public string Salt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Performance> Performances { get; set; } = new List<Performance>();
}