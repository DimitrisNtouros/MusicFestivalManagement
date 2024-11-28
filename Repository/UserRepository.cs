using Microsoft.EntityFrameworkCore;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Extensions;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FestivalContext _context;

        public UserRepository(FestivalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            var usersDto = users.Select(s => s.ToDto());
            return usersDto;
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user?.ToDto();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            return user?.ToDto();
        }

        public async Task AddUserAsync(CreateUserDto userDto)
        {
            var user = userDto.ToCreateDto();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(UpdateUserDto userDto, int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user != null)
            {
                user.Username = userDto.Username;
                user.Firstname = userDto.Firstname;
                user.Lastname = userDto.Lastname;
                user.Email = userDto.Email;
                user.PasswordHash = userDto.PasswordHash;
                user.PhoneNumber = userDto.PhoneNumber;
                user.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }


    }
}
