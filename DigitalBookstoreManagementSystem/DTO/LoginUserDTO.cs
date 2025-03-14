using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class LoginUserDTO
    {
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
