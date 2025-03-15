using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategoryAsync([FromBody] CategoryDTO categorydto)

        {
            if (categorydto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryRepository.AddCategoryAsync(categorydto);
            return Ok(categorydto);
        }
    }
}

