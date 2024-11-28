namespace MusicFestivalManagement.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } = null;// e.g., Lead Singer, Guitarist, etc.
        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }
    }
}
