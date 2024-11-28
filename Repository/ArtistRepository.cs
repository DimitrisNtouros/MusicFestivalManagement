using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Repository;

public class ArtistRepository : IArtistRepository
{
    private readonly FestivalContext _context;

    public ArtistRepository(FestivalContext context)
    {
        _context = context;
    }

    public async Task<Artist> GetArtistByIdAsync(int id)
    {
        return await _context.Artists.FindAsync(id);
    }

    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task AddArtistAsync(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateArtistAsync(Artist artist)
    {
        _context.Artists.Update(artist);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteArtistAsync(int id)
    {
        var artist = await GetArtistByIdAsync(id);
        if (artist != null)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }
    }
}