using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Dtos;

namespace MusicFestivalManagement.Repository;

public class FestivalRepository : IFestivalRepository
{
    private readonly FestivalContext _context;

    public FestivalRepository(FestivalContext context)
    {
        _context = context;
    }

    public async Task AddFestivalAsync(CreateFestivalDto festivalDto)
    {
        var festival = new Festival
        {
            FestivalId = festivalDto.FestivalId,
            Name = festivalDto.Name,
            Description = festivalDto.Description,
            StartDate = festivalDto.StartDate,
            EndDate = festivalDto.EndDate,
            Venue = festivalDto.Venue,
            State = festivalDto.State
        };
        _context.Festivals.Add(festival);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Festival>> GetAllFestivalsAsync()
    {
        return await _context.Festivals.ToListAsync();
    }

    public async Task<Festival> GetFestivalByIdAsync(int id)
    {
        return await _context.Festivals.FindAsync(id);
    }

    public async Task<Festival> GetFestivalByNameAsync(string name)
    {
        return await _context.Festivals.FirstOrDefaultAsync(f => f.Name == name);
    }

    public async Task UpdateFestivalAsync(Festival festival)
    {
        _context.Festivals.Update(festival);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFestivalAsync(int id)
    {
        var festival = await _context.Festivals.FindAsync(id);
        if (festival != null)
        {
            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Festival> CreateFestivalAsync(CreateFestivalDto dto, int creatorUserId)
{
    // Έλεγχος για μοναδικότητα του ονόματος
    if (await _context.Festivals.AnyAsync(f => f.Name == dto.Name))
    {
        throw new Exception("Festival name must be unique.");
    }

    // Δημιουργία του φεστιβάλ
    var festival = new Festival
    {
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Venue = dto.Venue,
        State = dto.State
    };

    // Αποθήκευση φεστιβάλ
    _context.Festivals.Add(festival);
    await _context.SaveChangesAsync();

    // Ανάκτηση του ρόλου ORGANIZER
    var organizerRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == 2);
    if (organizerRole == null)
    {
        throw new Exception("Role 'ORGANIZER' does not exist.");
    }

    // Ανάθεση ρόλου ORGANIZER στον δημιουργό
    var userRole = new UserRole
    {
        UserId = creatorUserId,
        RoleId = organizerRole.RoleId,
        FestivalId = festival.FestivalId
    };

    _context.UserRoles.Add(userRole);
    await _context.SaveChangesAsync();

    return festival;
}

}
