using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Extensions
{
    public static class FestivalExtensions
    {
        public static Festival ToFestival(this CreateFestivalDto dto)
        {
            return new Festival
            {
                FestivalId = dto.FestivalId,
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Venue = dto.Venue,
                State = "CREATED"
            };
        }

        public static Festival ToFestival(this UpdateFestivalDto dto)
        {
            return new Festival
            {
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Venue = dto.Venue,
                State = "UPDATED"
            };
        }
    }
}
