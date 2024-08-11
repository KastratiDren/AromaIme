using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await _categoryService.GetAllAsync();
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var category = await _categoryService.GetAsync(id);
            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
                return BadRequest("Category can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _categoryService.ExistsAsync(categoryDTO.Name);
            if (exists)
                return Conflict("Category already exists.");

            var createdDTO = await _categoryService.CreateAsync(categoryDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id == 0)
                return BadRequest("Id can't be zero.");

            var category = await _categoryService.DeleteAsync(id);
            if (category == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id == 0 || categoryDTO == null)
                return BadRequest("Id or category can't be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _categoryService.ExistsAsync(categoryDTO.Name);
            if (exists)
                return Conflict("Category already exists.");

            var updatedCategory = await _categoryService.UpdateAsync(id, categoryDTO);
            if (updatedCategory == null)
                return NotFound();

            return Ok(updatedCategory);
        }


    }
}
