using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Extensions
{
    public static class PerformanceExtensions
    {
        public static Performance ToPerformance(this CreatePerformanceDto dto)
        {
            return new Performance
            {
                Name = dto.Name,
                Description = dto.Description,
                Genre = dto.Genre,
                Duration = dto.Duration,
                FestivalId = dto.FestivalId,
                TechnicalRequirements = dto.TechnicalRequirements,
                Setlist = dto.Setlist,
                MerchandiseItems = dto.MerchandiseItems,
                PreferredRehearsalTimes = dto.PreferredRehearsalTimes,
                PreferredPerformanceSlots = dto.PreferredPerformanceSlots,
                State = "CREATED", // Προεπιλεγμένη τιμή
                CreationDate = DateTime.UtcNow // Αυτόματη τιμή
            };
        }

        public static void UpdateFromDto(this Performance performance, UpdatePerformanceDto dto)
        {
            performance.Name = dto.Name;
        }
    }
}
