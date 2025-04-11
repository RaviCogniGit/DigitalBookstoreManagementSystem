using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using DigitalBookstoreManagementSystem.Services.Service.CRUDService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] UserDTO userdto)

        {
            if (userdto == null) // Checks whether proper JSON body is provided for it 
            {
                return BadRequest("Invalid Data");
            }
            await _userService.AddUserAsync(userdto);
            return Ok(userdto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            var user = await _userService.GetUserByIDAsync(id);
            if (user == null)
            {
                return NotFound(id);
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserByIDAsync(int id)
        {
            var user = await _userService.GetUserByIDAsync(id);
            if (user == null)
            {
                return NotFound(id);
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userdto)
        {
            if (userdto == null || id != userdto.UserID)
            {
                return BadRequest("User ID mismatch or invalid data.");
            }

            await _userService.UpdateUserAsync(userdto);
            return Ok("User Updated Successfully.");
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(email);
            }

            return Ok(user);
        }

    }
}
