using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.ServiceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegisterService _userService;
        public RegisterUserController(IRegisterService userservice)
        {
            _userService = userservice;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userdto)
        {
            if (userdto == null)
            {
                return BadRequest("User Data is missing!");
            }
            var result = _userService.RegisterUser(userdto);

            return Ok(new { Message = "User Registered. Please Login!!" });
        }

    }
}
