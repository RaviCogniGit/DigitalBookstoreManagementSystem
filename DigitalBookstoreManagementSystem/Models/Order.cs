using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Tokens;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Order
    {
        public enum OrderStatus
        {
            Pending,
            Shipped,
            Delivered
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public required DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public required double TotalAmount { get; set; }
        public required OrderStatus Status { get; set; } 

        // Foreign Key

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        // Navigation Property
        protected virtual User? User { get; set; }
    }
}

