using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IInventoryService
    {
        public Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        public Task<Inventory> GetInventoryByIdAsync(int id);
        public Task<Inventory> AddInventoryAsync(InventoryDTO inventorydto);
        public Task<Inventory> UpdateInventoryAsync(InventoryDTO inventorydto);
        public Task DeleteInventoryAsync(int inventoryId);
    }
}
