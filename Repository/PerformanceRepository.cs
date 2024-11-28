using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Repository
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly FestivalContext _context;

        public PerformanceRepository(FestivalContext context)
        {
            _context = context;
        }

        public async Task<Performance> GetPerformanceByIdAsync(int id)
        {
            return await _context.Performances
                .Include(p => p.Artists)
                .FirstOrDefaultAsync(p => p.PerformanceId == id);
        }

        public async Task<IEnumerable<Performance>> GetAllPerformancesAsync()
        {
            return await _context.Performances
                .Include(p => p.Artists)
                .ToListAsync();
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByFestivalIdAsync(int festivalId)
        {
            return await _context.Performances
                .Where(p => p.FestivalId == festivalId)
                .Include(p => p.Artists)
                .ToListAsync();
        }

        public async Task AddPerformanceAsync(Performance performance)
        {
            _context.Performances.Add(performance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerformanceAsync(Performance performance)
        {
            _context.Performances.Update(performance);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerformanceAsync(int id)
        {
            var performance = await GetPerformanceByIdAsync(id);
            if (performance != null)
            {
                _context.Performances.Remove(performance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsPerformanceNameUniqueAsync(string name, int festivalId)
        {
            return !await _context.Performances.AnyAsync(p => p.Name == name && p.FestivalId == festivalId);
        }
    }
}
