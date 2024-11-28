using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Service;

public class FestivalService
{
    private readonly IFestivalRepository _repository;

    public FestivalService(IFestivalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Festival> CreateFestivalAsync(Festival festival)
    {
        festival.State = "CREATED";
        await _repository.AddFestivalAsync(festival);
        return festival;
    }

    public async Task<IEnumerable<Festival>> GetAllFestivalsAsync()
    {
        return await _repository.GetAllFestivalsAsync();
    }

    public async Task<Festival> GetFestivalByIdAsync(int id)
    {
        return await _repository.GetFestivalByIdAsync(id);
    }

    public async Task UpdateFestivalAsync(Festival festival)
    {
        await _repository.UpdateFestivalAsync(festival);
    }

    public async Task DeleteFestivalAsync(int id)
    {
        await _repository.DeleteFestivalAsync(id);
    }
}
