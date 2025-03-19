using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IUserService
    {
        Task AddUserAsync(UserDTO userdto);
        Task DeleteUserAsync(int userID);
        Task UpdateUserAsync(UserDTO userdto);
        Task<User> GetUserByIDAsync(int UserID);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string Email);

    }
}
