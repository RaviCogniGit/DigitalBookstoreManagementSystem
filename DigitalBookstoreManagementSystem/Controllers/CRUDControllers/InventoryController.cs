using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _context;

        public InventoryController(IInventoryService context)
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

            await _context.AddInventoryAsync(inventorydto);
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventorydto.InventoryID }, inventorydto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] InventoryDTO inventorydto)
        {
            if (inventorydto == null || id != inventorydto.InventoryID)
            {
                return BadRequest("Inventory ID mismatch or invalid data.");
            }

            await _context.UpdateInventoryAsync(inventorydto);
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
