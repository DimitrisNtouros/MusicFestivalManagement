namespace MusicFestivalManagement.Dtos
{
    public class UpdateUserDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
