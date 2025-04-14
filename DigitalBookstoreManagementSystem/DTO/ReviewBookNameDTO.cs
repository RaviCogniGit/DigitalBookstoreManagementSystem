using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class ReviewBookNameDTO
    {
          
        public int ReviewID { get; set; }

        public int Rating { get; set; }

        public required string Comment { get; set; }
        public required int UserID { get; set; }
        public required int BookID { get; set; }
        public required string Title { get; set; }

    }
}

