using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Extensions;
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
                .FirstOrDefaultAsync(p => p.PerformanceId == id);
        }

        public async Task<IEnumerable<Performance>> GetAllPerformancesAsync()
        {
            return await _context.Performances
                .ToListAsync();
        }

        public async Task<IEnumerable<Performance>> GetPerformancesByFestivalIdAsync(int festivalId)
        {
            return await _context.Performances
                .Where(p => p.FestivalId == festivalId)
                .ToListAsync();
        }

        public async Task AddPerformanceAsync(CreatePerformanceDto performance)
        {
            _context.Performances.Add(performance.ToPerformance());
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerformanceAsync(UpdatePerformanceDto dto)
        {
            var existingPerformance = await _context.Performances.FindAsync(dto.Id);

            if (existingPerformance == null)
            {
                throw new Exception("Performance not found");
            }

            existingPerformance.Name = dto.Name;

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

        public async Task<bool> FestivalExistsAsync(int festivalId)
        {
            return await _context.Festivals.AnyAsync(f => f.FestivalId == festivalId);
        }

        public async Task<bool> IsPerformanceNameUniqueAsync(string name, int festivalId)
        {
            return !await _context.Performances.AnyAsync(p => p.Name == name && p.FestivalId == festivalId);
        }
    }
}
