using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Category
    {
        [Key]
        public required int CategoryID { get; set; }
        public required string Name { get; set; }

        // Navigation Property
        public ICollection<Book>? book { get; set; }
    }
}
