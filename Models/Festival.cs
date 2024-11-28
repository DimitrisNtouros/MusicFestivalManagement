namespace MusicFestivalManagement.Models
{
    public class Festival
    {
        public int FestivalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Venue { get; set; }
        public string State { get; set; } // CREATED, SUBMISSION, etc.

        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
