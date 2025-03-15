using DigitalBookstoreManagementSystem.DTO;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(CategoryDTO categorydto);

    }
}
