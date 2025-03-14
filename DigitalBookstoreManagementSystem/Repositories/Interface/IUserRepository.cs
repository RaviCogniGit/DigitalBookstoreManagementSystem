using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IUserRepository
    {
        // Task is used for aysnchronous programming
        Task AddUser(User user);
        Task DeleteUser(int userID);
        Task UpdateUser(User user);
        Task<User> GetUserByID(int UserID);
        Task<IEnumerable<User>> GetAllUsers();
        // IEnumerable represents sequence of objects of a collection that can be enumerated(iterated)
        // The underlying collection type could be lists, arrays etc
        Task<User> GetUserByEmail(string email);
    }
}
