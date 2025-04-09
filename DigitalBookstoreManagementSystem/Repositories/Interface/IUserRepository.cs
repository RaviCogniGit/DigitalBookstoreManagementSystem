using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IUserRepository
    {
        // Task is used for aysnchronous programming
        public Task AddUserAsync(User user);
        public Task DeleteUserAsync(int userID);
        public Task<User> UpdateUserAsync(User user);
        public Task<User> GetUserByIDAsync(int UserID);
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetUserByEmailAsync(string Email);
    }
}
