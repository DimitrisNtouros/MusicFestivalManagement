namespace MusicFestivalManagement.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        // Ξένες Κλείδες
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int FestivalId { get; set; }
        public Festival Festival { get; set; }
    }
}
