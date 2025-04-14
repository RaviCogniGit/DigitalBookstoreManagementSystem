using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookAuthorDTO>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string searchText);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(int id);
    }
}