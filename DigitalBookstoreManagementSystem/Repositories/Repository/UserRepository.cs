using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        // Dependency Injection (Constructor Injection), Part of the overall Inversion of Control SOLID Principles.
        // IoC is a principle in software design where the control of object creation and dependency management is transferred from the class itself to an external entity.
        private readonly DigitalBookstoreManagementSystemDBContext _context;

        // Constructor Template for creating objects (Datatype Variable_Name)
        public UserRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context; // _contesxt is the instance of the class DigitalBookstoreManagmentSystemDBContext
        }
                                                                                                                                                                                    
        // Create Operation
        public async Task AddUser(User user) // We did not do Adduser(var user) because it would lead to compile time error. 
        {
            if (user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        // Delete Operation
        public async Task DeleteUser(int UserID)
        {
            var user = await _context.Users.FindAsync(UserID);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // Read Operation
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Read Operation
        public async Task<User> GetUserByID(int UserID)
        {
            return await _context.Users.FindAsync(UserID);
        }

        // Update Operation
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

    }
}
