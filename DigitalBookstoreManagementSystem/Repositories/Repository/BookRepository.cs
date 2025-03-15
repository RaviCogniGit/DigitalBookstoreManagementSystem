using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;

        public BookRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int BookID)
        {
            return await _context.Books.FindAsync(BookID);
        }

        public async Task<Book> AddBookAsync(BookDTO bookdto)
        {
            var book = new Book
            {
                BookID = bookdto.BookID,
                Title = bookdto.Title,
                Price = bookdto.Price,
                StockQuantity = bookdto.StockQuantity,
                AuthorID = bookdto.AuthorID,
                CategoryID = bookdto.CategoryID,
            };

            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(int id, BookDTO bookdto)
        {
            var book = new Book
            {
                BookID = bookdto.BookID,
                Title = bookdto.Title,
                Price = bookdto.Price,
                StockQuantity = bookdto.StockQuantity,
                AuthorID = bookdto.AuthorID,
                CategoryID = bookdto.CategoryID,
            };
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
