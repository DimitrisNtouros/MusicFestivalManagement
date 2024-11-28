using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllDoctors()
    {
        try
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }


    [HttpGet("username/{username}")]
    [Authorize]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        try
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto userDto)
    {
        if (userDto == null || string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.PasswordHash))
        {
            return BadRequest(new { Message = "Invalid user data" });
        }

        try
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                return Conflict(new { Message = "Username already exists" });
            }

            await _userRepository.AddUserAsync(userDto);
            return Ok(new { Message = "User added successfully" });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new { Message = ex.Message });
        }
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest(new { Message = "Invalid user data" });
        }

        try
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            await _userRepository.UpdateUserAsync(userDto, id);
            return Ok(new { Message = "User updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            await _userRepository.DeleteUserAsync(id);
            return Ok(new { Message = "User deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = ex.Message });
        }
    }
}
