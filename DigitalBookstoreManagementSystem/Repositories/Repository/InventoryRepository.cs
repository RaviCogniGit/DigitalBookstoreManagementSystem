using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;

        public InventoryRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        // Used FirstOrDefaultAsync because FindAsync does not take lambda expression as parameter.
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventories.FirstOrDefaultAsync(i => i.InventoryID == id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task DeleteInventoryAsync(int inventoryId)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryId);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }

    }
}