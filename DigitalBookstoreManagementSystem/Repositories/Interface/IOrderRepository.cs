using DigitalBookstoreManagementSystem.Models;
using static DigitalBookstoreManagementSystem.Models.Order;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
        Task<bool> UpdateOrderStatus(int id, OrderStatus status);
        Task<bool> DeleteOrder(int orderId);
    }
}

