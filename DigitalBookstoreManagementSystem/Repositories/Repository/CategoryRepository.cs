using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;
        public CategoryRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context;
        }
        public async Task AddCategoryAsync(CategoryDTO categorydto)
        {
            var category = new Category
            {
                CategoryID = 0,
                CategoryName = categorydto.CategoryName,
            };

            if (categorydto != null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
    

