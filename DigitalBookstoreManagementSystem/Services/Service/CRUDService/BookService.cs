using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Repositories.Repository;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Services.Service.CRUDService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int BookID)
        {
            return await _bookRepository.GetBookByIdAsync(BookID);
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

            return await _bookRepository.AddBookAsync(book);
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

            await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }



    }
}
