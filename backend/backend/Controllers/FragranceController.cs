using backend.DTOs;
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
                return BadRequest("Id can't be zero.");

            var fragrance = await _fragranceService.GetAsync(id);
            if (fragrance == null)
                return NotFound();

            return Ok(fragrance);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FragranceDTO fragranceDTO)
        {
            if (fragranceDTO == null)
                return BadRequest("Fragrance can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _fragranceService.ExistsAsync(fragranceDTO.Name);
            if (exists)
                return Conflict("Fragrance already exists.");

            var createdDTO = await _fragranceService.CreateAsync(fragranceDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var fragrance = await _fragranceService.DeleteAsync(id);
            if (fragrance == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FragranceDTO fragranceDTO)
        {
            if (id == 0 || fragranceDTO == null)
                return BadRequest("Id or fragrance can't be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _fragranceService.ExistsAsync(fragranceDTO.Name);
            if (exists)
                return Conflict("Fragrance already exists.");

            var updatedFragrance = await _fragranceService.UpdateAsync(id, fragranceDTO);
            if (updatedFragrance == null)
                return NotFound();

            return Ok(updatedFragrance);
        }
    }
}

