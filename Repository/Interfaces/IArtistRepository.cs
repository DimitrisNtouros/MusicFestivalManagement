using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Repository.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtistByIdAsync(int id);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task AddArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        Task DeleteArtistAsync(int id);
    }
}
