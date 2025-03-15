using DigitalBookstoreManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Cannot exceed 500 characters")]
        public required string Comment { get; set; }
        public required int UserID { get; set; }
        public required int BookID { get; set; }

    }
}
