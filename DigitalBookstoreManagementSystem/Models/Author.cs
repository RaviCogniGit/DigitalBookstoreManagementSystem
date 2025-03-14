using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Author
    {
        [Key]
        public required int AuthorID { get; set; }
        public required string Name { get; set; }
    }
}
