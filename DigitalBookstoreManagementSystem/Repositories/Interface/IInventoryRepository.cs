using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        public Task<Inventory> GetInventoryByIdAsync(int id);
        public Task<Inventory> AddInventoryAsync(Inventory inventory);
        public Task<Inventory> UpdateInventoryAsync(Inventory inventory);
        public Task DeleteInventoryAsync(int inventoryId);

    }
}
