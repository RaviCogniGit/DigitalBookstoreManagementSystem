using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
        public required string Title { get; set; }
        public required double Price { get; set; }
        public required int StockQuantity { get; set; }

        // Foreign Key
        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        // Navigation Property
        public virtual Author? Author { get; set; }  // Check Required or ? or Ignore the warning
        public virtual Category? Category { get; set; }

    }
}
