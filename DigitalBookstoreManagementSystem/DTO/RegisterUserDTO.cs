using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class RegisterUserDTO
    {
        public required string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
