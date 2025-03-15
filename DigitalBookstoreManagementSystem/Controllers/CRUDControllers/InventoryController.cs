using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _context;

        public InventoryController(IInventoryRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventories()
        {
            var inventories = await _context.GetAllInventoriesAsync();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var inventory = await _context.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound($"Inventory with ID {id} not found.");

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> AddInventory([FromBody] InventoryDTO inventorydto)
        {
            if (inventorydto == null)
            {
                return BadRequest("Invalid inventory data.");
            }
            var inventory = new Inventory
            {
                InventoryID = inventorydto.InventoryID,
                Quantity = inventorydto.Quantity,
                BookID = inventorydto.BookID,
            };

            await _context.AddInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.InventoryID }, inventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] InventoryDTO inventorydto)
        {
            if (inventorydto == null || id != inventorydto.InventoryID)
            {
                return BadRequest("Inventory ID mismatch or invalid data.");
            }
            var inventory = new Inventory
            {
                InventoryID = inventorydto.InventoryID,
                Quantity = inventorydto.Quantity,
                BookID = inventorydto.BookID,
            };

            await _context.UpdateInventoryAsync(inventory);
            return Ok("Inventory Updated Successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var existingInventory = await _context.GetInventoryByIdAsync(id);
            if (existingInventory == null)
                return NotFound("Inventory not found!");

            await _context.DeleteInventoryAsync(id);
            return NoContent();
        }

    }
}
