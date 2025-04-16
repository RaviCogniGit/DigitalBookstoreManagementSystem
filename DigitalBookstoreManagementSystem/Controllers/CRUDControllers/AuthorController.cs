using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Repositories.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthorAsync([FromBody] AuthorDTO authordto)

        {
            if (authordto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _authorRepository.AddAuthorAsync(authordto);
            return Ok(authordto);
        }
    }
}
