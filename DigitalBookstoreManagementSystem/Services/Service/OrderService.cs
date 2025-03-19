using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Services.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }
        public async Task<Order> CreateOrder(OrderDTO orderdto)
        {
            var order = new Order
            {
                OrderID = orderdto.OrderID,
                OrderDate = orderdto.OrderDate,
                TotalAmount = orderdto.TotalAmount,
                Status = orderdto.Status,
                UserID = orderdto.UserID,
            };

            return await _orderRepository.CreateOrder(order);
        }
        public async Task<bool> UpdateOrderStatus(int id, OrderStatus status)
        {
            return await _orderRepository.UpdateOrderStatus(id, status);

        }
        public async Task<bool> DeleteOrder(int orderId)
        {
            return await _orderRepository.DeleteOrder(orderId);
        }
    }
}

