using DigitalBookstoreManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public required string Title { get; set; }
        public required double Price { get; set; }
        public required int StockQuantity { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
    }
}
