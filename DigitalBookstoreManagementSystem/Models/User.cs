using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DigitalBookstoreManagementSystem.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID {  get; set; }
        public required string Name { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public required string Email{ get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        //Navigation Property
        protected virtual Review? Review { get; set; } 

    }
}
