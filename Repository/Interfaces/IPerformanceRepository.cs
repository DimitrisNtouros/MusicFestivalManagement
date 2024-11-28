using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Repository.Interfaces
{
    public interface IPerformanceRepository
    {
        Task<Performance> GetPerformanceByIdAsync(int id);
        Task<IEnumerable<Performance>> GetAllPerformancesAsync();
        Task<IEnumerable<Performance>> GetPerformancesByFestivalIdAsync(int festivalId);
        Task AddPerformanceAsync(Performance performance);
        Task UpdatePerformanceAsync(Performance performance);
        Task DeletePerformanceAsync(int id);
        Task<bool> IsPerformanceNameUniqueAsync(string name, int festivalId);
    }
}
