using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Repository;

public class FestivalRepository : IFestivalRepository
{
    private readonly FestivalContext _context;

    public FestivalRepository(FestivalContext context)
    {
        _context = context;
    }

    public async Task<Festival> GetFestivalByIdAsync(int id)
    {
        return await _context.Festivals
            .Include(f => f.Performances)
            .FirstOrDefaultAsync(f => f.FestivalId == id);
    }

    public async Task<IEnumerable<Festival>> GetAllFestivalsAsync()
    {
        return await _context.Festivals
            .Include(f => f.Performances)
            .ToListAsync();
    }

    public async Task AddFestivalAsync(Festival festival)
    {
        _context.Festivals.Add(festival);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFestivalAsync(Festival festival)
    {
        _context.Festivals.Update(festival);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFestivalAsync(int id)
    {
        var festival = await GetFestivalByIdAsync(id);
        if (festival != null)
        {
            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();
        }
    }
}
