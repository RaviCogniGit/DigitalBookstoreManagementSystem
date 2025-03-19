using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.ServiceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _userService;
        public AccountController(IAccountService userservice)
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userdto)
        {
            if (userdto == null)
            {
                return BadRequest("User Data is missing!");
            }
            var result = await _userService.RegisterUser(userdto);

            return Ok(new { Message = "User Registered. Please Login!!" });
        }
    }
}