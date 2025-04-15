using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class UserReviewDto
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Cannot exceed 500 characters")]
        public required string Comment { get; set; }
        public required int UserID { get; set; }
        public required int BookID { get; set; }
        public required string Title { get; set; }

    }
}
