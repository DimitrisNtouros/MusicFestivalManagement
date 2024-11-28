using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Repository.Interfaces;
using MusicFestivalManagement.Settings;

namespace MusicFestivalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAuthenticationController : ControllerBase
    {
        protected readonly JWTSettings jwtSettings;
        private readonly IUserRepository _userRepository;

        public BaseAuthenticationController(IOptions<JWTSettings> options, IUserRepository userRepository)
        {
            this.jwtSettings = options.Value;
            this._userRepository = userRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var user1 = this._userRepository.GetUserByUsernameAsync(user.Username).Result;
            if (user1 == null)
            {
                return NotFound();
            }
            var found = Helpers.PasswordHasher.VerifyPassword(user.Password, user1.Salt, user1.PasswordHash);
            if (!found)
            {
                return NotFound("User not found");
            }
            TokenService tokenService = new TokenService(this.jwtSettings);

            var tokenString = tokenService.GenerateToken(user1);

            return Ok(new JWTTokenResponse
            {
                AuthToken = tokenString
            });

        }

    }
}
