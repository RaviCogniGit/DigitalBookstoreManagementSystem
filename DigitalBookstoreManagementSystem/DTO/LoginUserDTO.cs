using System.ComponentModel.DataAnnotations;

namespace DigitalBookstoreManagementSystem.DTO
{
    public class LoginUserDTO
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
