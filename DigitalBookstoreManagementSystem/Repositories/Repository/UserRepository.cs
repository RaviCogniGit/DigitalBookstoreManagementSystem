using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DigitalBookstoreManagementSystem.DTO;


namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DigitalBookstoreManagementSystemDBContext _context;

        // Constructor Injection
        public UserRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context; 
        }
                                                                                                                                                                                    
        // Create Operation
        public async Task AddUserAsync(User user)  
        {
            if (user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        // Delete Operation
        public async Task DeleteUserAsync(int UserID)
        {
            var user = await _context.Users.FindAsync(UserID);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // Read Operation
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Read Operation
        public async Task<User> GetUserByIDAsync(int UserID)
        {
            return await _context.Users.FindAsync(UserID);
        }

        // Update Operation
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Account Service - Authenticate User Method

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

    }
}
