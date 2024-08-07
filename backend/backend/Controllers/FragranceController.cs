using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FragranceController : ControllerBase
    {
        private readonly FragranceService _fragranceService;

        public FragranceController(FragranceService fragranceService)
        {
            _fragranceService = fragranceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fragrances = await _fragranceService.GetAllAsync();
            return Ok(fragrances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var fragrance = await _fragranceService.GetAsync(id);
            if (fragrance == null)
                return NotFound();

            return Ok(fragrance);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FragranceDto fragranceDto)
        {
            if (fragranceDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDto = await _fragranceService.CreateAsync(fragranceDto);
            return Ok(createdDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var fragrance = await _fragranceService.DeleteAsync(id);
            if (fragrance == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FragranceDto fragranceDto)
        {
            if (id == 0 || fragranceDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedFragrance = await _fragranceService.UpdateAsync(id, fragranceDto);
            if (updatedFragrance == null)
                return NotFound();

            return Ok(updatedFragrance);
        }
    }
}

