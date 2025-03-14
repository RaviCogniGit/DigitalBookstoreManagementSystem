using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace DigitalBookstoreManagementSystem.Services.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenRepository tokenRepository;

        public RegisterService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            this.userRepository = userRepository;
            this.tokenRepository = tokenRepository;
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

            await userRepository.AddUser(user);
            return true;
        }

    }
}
