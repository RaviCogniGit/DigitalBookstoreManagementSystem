using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DigitalBookstoreManagementSystem.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Cannot exceed 500 characters")]
        public required string Comment { get; set; }

        //Foreign key

        [ForeignKey(nameof(User))]
        public required int UserID { get; set; }

        [ForeignKey(nameof(Book))]
        public required int BookID { get; set; }

        //Navigation Property
        protected virtual User? User { get; set; }
        protected virtual Book? Book { get; set; }
    }
}
