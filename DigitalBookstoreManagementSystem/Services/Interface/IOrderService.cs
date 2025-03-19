using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IOrderService 
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order> CreateOrder(OrderDTO orderdto);
        Task<bool> UpdateOrderStatus(int id, OrderStatus status);
        Task<bool> DeleteOrder(int orderId);
    }
}
