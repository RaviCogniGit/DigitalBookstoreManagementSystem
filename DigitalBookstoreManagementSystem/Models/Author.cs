using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Author
    {
        [Key]
        public required int AuthorID { get; set; }
        public required string AuthorName { get; set; }

        // Navigation Property
        public ICollection<Book>? book { get; set; }
    }
}
