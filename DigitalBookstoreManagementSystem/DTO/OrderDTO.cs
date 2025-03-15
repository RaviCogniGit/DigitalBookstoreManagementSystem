using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public required DateTime OrderDate { get; set; }
        public required double TotalAmount { get; set; }
        public required OrderStatus Status { get; set; }
        public int UserID { get; set; }
    }
}
