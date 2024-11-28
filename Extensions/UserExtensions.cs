using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;

namespace MusicFestivalManagement.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.UserId,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Salt = user.Salt,
            };
        }

        public static User ToModel(this UserDto userDto)
        {
            return new User
            {
                UserId = userDto.Id,
                Username = userDto.Username,
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
            };
        }
        public static User ToCreateDto(this CreateUserDto userDto)
        {
            var hashPassword = Helpers.PasswordHasher.HashPassword(userDto.PasswordHash);
            return new User
            {
                Username = userDto.Username,
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Email = userDto.Email,
                PasswordHash = hashPassword.Item1,
                Salt = hashPassword.Item2,
                PhoneNumber = userDto.PhoneNumber,
            };
        }
    }
}
