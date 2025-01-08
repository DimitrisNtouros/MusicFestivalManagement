using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Repository.Interfaces
{
    public interface IPerformanceRepository
    {
        Task<Performance> GetPerformanceByIdAsync(int id);
        Task<IEnumerable<Performance>> GetAllPerformancesAsync();
        Task<IEnumerable<Performance>> GetPerformancesByFestivalIdAsync(int festivalId);
        Task AddPerformanceAsync(CreatePerformanceDto performance);
        Task UpdatePerformanceAsync(UpdatePerformanceDto dto);
        Task DeletePerformanceAsync(int id);
        Task<bool> FestivalExistsAsync(int festivalId);
        Task<bool> IsPerformanceNameUniqueAsync(string name, int festivalId);
    }
}
