using MusicFestivalManagement.Dtos;

namespace MusicFestivalManagement.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task AddUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(UpdateUserDto userDto, int id);
        Task DeleteUserAsync(int userId);
    }
}
