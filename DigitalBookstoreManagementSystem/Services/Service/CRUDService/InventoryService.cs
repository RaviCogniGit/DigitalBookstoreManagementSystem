using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Services.Service.CRUDService
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _inventoryRepository.GetAllInventoriesAsync();
        }

        // Used FirstOrDefaultAsync because FindAsync does not take lambda expression as parameter.
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(id);
        }

        public async Task<Inventory> AddInventoryAsync(InventoryDTO inventorydto)
        {
            var inventory = new Inventory
            {
                InventoryID = inventorydto.InventoryID,
                Quantity = inventorydto.Quantity,
                BookID = inventorydto.BookID,
            };
            return await _inventoryRepository.AddInventoryAsync(inventory);
        }

        public async Task<Inventory> UpdateInventoryAsync(InventoryDTO inventorydto)
        {
            var inventory = new Inventory
            {
                InventoryID = inventorydto.InventoryID,
                Quantity = inventorydto.Quantity,
                BookID = inventorydto.BookID,
            };
            return await _inventoryRepository.UpdateInventoryAsync(inventory);
        }

        public async Task DeleteInventoryAsync(int inventoryId)
        {
            await _inventoryRepository.DeleteInventoryAsync(inventoryId);
        }
    }
}
