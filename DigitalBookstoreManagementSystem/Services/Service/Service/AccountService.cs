using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace DigitalBookstoreManagementSystem.Services.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public AccountService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> AuthenticateUser(LoginUserDTO logindto)
        {
            var user = await _userRepository.GetUserByEmailAsync(logindto.Email);
            if (user == null || logindto.Password != user.Password)
            {
                return null;
            }

            var roles = new List<string> { user.Role };

            var token = _tokenRepository.CreateJWTToken(new IdentityUser { Email = user.Email }, roles);

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

            await _userRepository.AddUserAsync(user);
            return true;
        }
    }
}
