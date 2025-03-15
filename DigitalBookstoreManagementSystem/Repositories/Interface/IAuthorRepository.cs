using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface

{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(AuthorDTO authordto);
    }
}
