using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("BookId")]
        public int BookID { get; set; }

        [Column("Title")]
        public required string Title { get; set; }
        [Column("Price")]
        public required double Price { get; set; }
        [Column("StockQuantity")]
        public required int StockQuantity { get; set; }

        // Foreign Key
        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        // Navigation Property
        public Author? Author { get; set; }  
        public Category? Category { get; set; }

    }
}
