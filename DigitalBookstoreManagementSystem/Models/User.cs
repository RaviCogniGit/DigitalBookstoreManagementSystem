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
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email{ get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        //Navigation Property
        protected virtual Review? Review { get; set; } 

    }
}
