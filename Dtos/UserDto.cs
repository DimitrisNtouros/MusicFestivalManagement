namespace MusicFestivalManagement.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Salt { get; set; }
        public int Role { get; set; }
    }
}
