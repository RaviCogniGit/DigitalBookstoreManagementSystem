using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;
        public AuthorRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context; 
        }
        public async Task AddAuthorAsync(AuthorDTO authordto) 
        {
            var author = new Author
            {
                AuthorID = 0,
                Name = authordto.Name,
            };
            if (authordto != null)
            {
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
