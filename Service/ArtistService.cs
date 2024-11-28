using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Service;

public class ArtistService
{
    private readonly IArtistRepository _repository;

    public ArtistService(IArtistRepository repository)
    {
        _repository = repository;
    }

    public async Task<Artist> CreateArtistAsync(Artist artist)
    {
        if (string.IsNullOrEmpty(artist.Name))
            throw new Exception("Artist name is required");

        await _repository.AddArtistAsync(artist);
        return artist;
    }

    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {
        return await _repository.GetAllArtistsAsync();
    }

    public async Task<Artist> GetArtistByIdAsync(int id)
    {
        return await _repository.GetArtistByIdAsync(id);
    }

    public async Task UpdateArtistAsync(Artist artist)
    {
        await _repository.UpdateArtistAsync(artist);
    }

    public async Task DeleteArtistAsync(int id)
    {
        await _repository.DeleteArtistAsync(id);
    }
}
