using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(BookDTO bookdto);
        Task<IEnumerable<Book>> SearchBooksAsync(string searchText);
        Task UpdateBookAsync(int id, BookDTO bookdto);
        Task DeleteBookAsync(int id);
    }
}
