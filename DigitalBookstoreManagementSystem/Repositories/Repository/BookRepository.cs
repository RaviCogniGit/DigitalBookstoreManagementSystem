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

        public async Task<IEnumerable<BookAuthorDTO>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Select(b => new BookAuthorDTO
                {
                    BookID = b.BookID,
                    Title = b.Title,
                    StockQuantity = b.StockQuantity,
                    Price = b.Price,
                    AuthorID = b.AuthorID,
                    AuthorName = b.Author.AuthorName,
                    CategoryID = b.CategoryID,
                    CategoryName = b.Category.CategoryName
                })
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int BookID)
        {
            return await _context.Books.FindAsync(BookID);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
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

        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchText)
        {
            List<Book> books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Title.Contains(searchText) || b.Author.AuthorName.Contains(searchText) || b.Category.CategoryName.Contains(searchText))
                .ToListAsync();
            return books;
        }
    }
}


