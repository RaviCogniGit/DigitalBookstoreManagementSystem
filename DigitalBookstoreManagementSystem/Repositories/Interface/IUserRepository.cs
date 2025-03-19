using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IUserRepository
    {
        // Task is used for aysnchronous programming
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int userID);
        Task UpdateUserAsync(User user);
        Task<User> GetUserByIDAsync(int UserID);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string Email);

    }
}
