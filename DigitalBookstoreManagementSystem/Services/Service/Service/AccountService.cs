using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace DigitalBookstoreManagementSystem.Services.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenRepository tokenRepository;

        public AccountService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            this.userRepository = userRepository;
            this.tokenRepository = tokenRepository;
        }

        public async Task<string> AuthenticateUser(LoginUserDTO logindto)
        {
            var user = await userRepository.GetUserByEmailAsync(logindto.Email);
            if (user == null || logindto.Password != user.Password)
            {
                return null;
            }

            var roles = new List<string> { user.Role };

            var token = tokenRepository.CreateJWTToken(new IdentityUser { Email = user.Email }, roles);

            return token;
        }

        public async Task<bool> RegisterUser(RegisterUserDTO userdto)
        {
            if (userdto == null)
            {
                return false;
            }
            var user = new User
            {
                UserID = 0,
                Name = userdto.Name,
                Email = userdto.Email,
                Password = userdto.Password,
                Role = userdto.Role
            };

            await userRepository.AddUserAsync(user);
            return true;
        }
    }
}
