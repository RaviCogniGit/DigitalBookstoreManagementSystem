using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.ServiceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly ILoginService _userService;
        public LoginUserController(ILoginService userservice)
        {
            _userService = userservice;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO logindto)
        {
            var token = await _userService.AuthenticateUser(logindto);
            if (token == null)
            {
                return Unauthorized(new { Message = "Oops! You cannot access the resource" });
            }
            return Ok(new { JwtToken = token });
        }
    }
}
