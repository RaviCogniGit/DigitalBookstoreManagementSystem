using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static DigitalBookstoreManagementSystem.Models.Order;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;

        public OrderRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<bool> UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;  //order is not found

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;  //deleted successfullyy
        }
    }
}
