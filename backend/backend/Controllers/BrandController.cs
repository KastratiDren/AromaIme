using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandService _brandService;
        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var brand = await _brandService.GetAsync(id);
            if(brand == null)
                return NotFound();

            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDTO brandDTO)
        {
            if(brandDTO == null)
                return BadRequest("Brand can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _brandService.ExistsAsync(brandDTO.Name);
            if (exists)
                return Conflict("Brand already exists.");


            var createdDTO = await _brandService.CreateAsync(brandDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id == 0)
                return BadRequest("Id can't be zero.");

            var brand = await _brandService.DeleteAsync(id);
            if (brand == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BrandDTO brandDTO)
        {
            if (id == 0 || brandDTO == null)
                return BadRequest("Id or brand can't be zero/null.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool exists = await _brandService.ExistsAsync(brandDTO.Name);
            if (exists)
                return Conflict("Brand already exists.");

            var updatedBrand = await _brandService.UpdateAsync(id, brandDTO);
            if (updatedBrand == null)
                return NotFound();

            return Ok(updatedBrand);
        }


    }
}
