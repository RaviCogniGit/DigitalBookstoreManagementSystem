using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Repositories.Repository;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace DigitalBookstoreManagementSystem.Services.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenRepository tokenRepository;

        public LoginService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            this.userRepository = userRepository;
            this.tokenRepository = tokenRepository;
        }

        public async Task<string> AuthenticateUser(LoginUserDTO logindto)
        {
            var user = await userRepository.GetUserByEmail(logindto.Email);
            if (user == null || logindto.Password != user.Password)
            {
                return null;
            }

            var roles = new List<string> { user.Role };

            var token = tokenRepository.CreateJWTToken(new IdentityUser { Email = user.Email }, roles);

            return token;
        }
    }
}
