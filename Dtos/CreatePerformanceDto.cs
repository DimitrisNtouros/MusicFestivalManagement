namespace MusicFestivalManagement.Dtos
{
    public class CreatePerformanceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // σε λεπτά
        public int FestivalId { get; set; } // Αναφορά στο Festival
        public string TechnicalRequirements { get; set; } // Path σε αρχείο ή περιγραφή
        public string Setlist { get; set; } // JSON string για τα τραγούδια
        public string MerchandiseItems { get; set; } // JSON string για αντικείμενα εμπορίου
        public string PreferredRehearsalTimes { get; set; } // JSON string
        public string PreferredPerformanceSlots { get; set; } // JSON string
    }
}