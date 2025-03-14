using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static DigitalBookstoreManagementSystem.Repositories.Repository.TokenRepository;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class TokenRepository : ITokenRepository
        {
            private readonly IConfiguration _configuration;
            public TokenRepository(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string CreateJWTToken(IdentityUser user, List<string> roles)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                Console.WriteLine($"Generated JWT token: {tokenString}");

                return tokenString;
            }
        }
}
 

