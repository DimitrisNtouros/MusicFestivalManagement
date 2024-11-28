using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Repository.Interfaces
{
    public interface IFestivalRepository
    {
        Task<Festival> GetFestivalByIdAsync(int id);
        Task<IEnumerable<Festival>> GetAllFestivalsAsync();
        Task AddFestivalAsync(Festival festival);
        Task UpdateFestivalAsync(Festival festival);
        Task DeleteFestivalAsync(int id);
    }
}
