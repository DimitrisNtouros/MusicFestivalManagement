using Microsoft.IdentityModel.Tokens;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService
{
    protected readonly JWTSettings _configuration;

    public TokenService(JWTSettings configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(UserDto user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.Role.ToString())
            };

        var tokenOptions = new JwtSecurityToken(
        issuer: _configuration.ValidIssuer,
        audience: _configuration.ValidAudience,
        claims: claims,
        expires: DateTime.Now.AddHours(2),
        signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}