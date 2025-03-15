using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Dependency Injection to provide Usercontroller with an instance of IUserRepository
        private readonly IUserRepository _context;

        public UserController(IUserRepository context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] UserDTO userdto)
        // The method take a parameter user of type User which would be provided in the body of the http post request from postman.
        {
            if (userdto == null) // Checks whether proper JSON body is provided for it 
            {
                return BadRequest("Invalid Data");
            }
            var user = new User
            {
                Name = userdto.Name,
                Email = userdto.Email,
                Role = userdto.Role,
                Password = userdto.Password
            };
            await _context.AddUser(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.GetUserByID(id);
            if (user == null)
            {
                return NotFound(id);
            }

            await _context.DeleteUser(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var user = await _context.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(int id)
        {
            var user = await _context.GetUserByID(id);
            if (user == null)
            {
                return NotFound(id);
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UserDTO userdto)
        {
            if (id != userdto.UserID)
            {
                return BadRequest("Entered ID does not match!");
            }
            var user = new User
            {
                Name = userdto.Name,
                Email = userdto.Email,
                Role = userdto.Role,
                Password = userdto.Password
            };
            await _context.UpdateUser(user);
            return NoContent();
        }

    }
}
