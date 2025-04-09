using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Repositories.Repository;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Services.Service.CRUDService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(UserDTO userdto)
        {
            var user = new User
            {
                Name = userdto.Name,
                Email = userdto.Email,
                Role = userdto.Role,
                Password = userdto.Password
            };
            await _userRepository.AddUserAsync(user);
        }

        // Delete Operation
        public async Task DeleteUserAsync(int UserID)
        {
            await _userRepository.DeleteUserAsync(UserID);
        }

        // Read Operation
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Read Operation
        public async Task<User> GetUserByIDAsync(int UserID)
        {
            return await _userRepository.GetUserByIDAsync(UserID);
        }

        public async Task UpdateUserAsync(UserDTO userdto)
        {
            var user = await _userRepository.GetUserByIDAsync(userdto.UserID);
            if (user != null)
            {
                user.Name = userdto.Name;
                user.Email = userdto.Email;
                user.Role = userdto.Role;
                user.Password = userdto.Password;

                await _userRepository.UpdateUserAsync(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

    }
}
