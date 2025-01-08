using System.Text.Json.Serialization;

namespace MusicFestivalManagement.Dtos
{
    public class UpdateFestivalDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Venue { get; set; }
        [JsonIgnore]
        public string State { get; set; } = "UPDATED";
    }
    
}
