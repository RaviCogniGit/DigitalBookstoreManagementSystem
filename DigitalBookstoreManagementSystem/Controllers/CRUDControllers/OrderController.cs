using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalBookstoreManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using DigitalBookstoreManagementSystem.Services.Interface;
using DigitalBookstoreManagementSystem.Services.Service;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] OrderDTO orderdto)
        {
            if (orderdto == null)
            {
                return BadRequest("Invalid order data.");
            }

            await _orderService.CreateOrder(orderdto);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderdto.OrderID }, orderdto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatus(int id,[FromBody] OrderStatus status)
        {
            var result = await _orderService.UpdateOrderStatus(id, status);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
