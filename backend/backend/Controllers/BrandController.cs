using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
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
                return BadRequest();

            var brand = await _brandService.GetAsync(id);
            if(brand == null)
                return NotFound();

            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDTO brandDTO)
        {
            if(brandDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDTO = await _brandService.CreateAsync(brandDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id == 0)
                return BadRequest();

            var brand = await _brandService.DeleteAsync(id);
            if (brand == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BrandDTO brandDTO)
        {
            if (id == 0 || brandDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBrand = await _brandService.UpdateAsync(id, brandDTO);
            if (updatedBrand == null)
                return NotFound();

            return Ok(updatedBrand);
        }


    }
}
