using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Repository.Interfaces;

public interface IFestivalRepository
{
    Task AddFestivalAsync(CreateFestivalDto festival);
    Task<IEnumerable<Festival>> GetAllFestivalsAsync();
    Task<Festival> GetFestivalByIdAsync(int id);
    Task<Festival> GetFestivalByNameAsync(string name); // Νέα μέθοδος
    Task UpdateFestivalAsync(Festival festival);
    Task DeleteFestivalAsync(int id);
}
