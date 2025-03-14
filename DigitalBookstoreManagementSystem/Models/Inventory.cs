using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int InventoryID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }

        // Foreign Key

        [Required(ErrorMessage = "BookID is required")]
        [ForeignKey(nameof(Book))]
        public required int BookID { get; set; }

        // Navigation property
        protected virtual Book? Book { get; set; }

    }
}
