namespace MusicFestivalManagement.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // σε λεπτά
        public DateTime CreationDate { get; set; }
        public string State { get; set; } // CREATED, SUBMITTED, REVIEWED, etc.
        public int FestivalId { get; set; }
        public Festival Festival { get; set; }
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
        public string TechnicalRequirements { get; set; } // Μπορεί να είναι path σε αρχείο
        public string Setlist { get; set; } // JSON string για τα τραγούδια
        public string MerchandiseItems { get; set; } // JSON string για αντικείμενα εμπορίου
        public string PreferredRehearsalTimes { get; set; } // JSON string
        public string PreferredPerformanceSlots { get; set; } // JSON string
    }
}
