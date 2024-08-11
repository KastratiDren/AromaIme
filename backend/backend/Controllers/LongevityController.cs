using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LongevityController : ControllerBase
    {
        private readonly LongevityService _longevityService;
        public LongevityController(LongevityService longevityService)
        {
            _longevityService = longevityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var longevities = await _longevityService.GetAllAsync();
            return Ok(longevities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var longevity = await _longevityService.GetAsync(id);
            if (longevity == null)
                return NotFound();

            return Ok(longevity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] LongevityDTO longevityDTO)
        {
            if (longevityDTO == null)
                return BadRequest("Longevity can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _longevityService.ExistsAsync(longevityDTO.Name);
            if (exists)
                return Conflict("Longevity already exists.");

            var createdDTO = await _longevityService.CreateAsync(longevityDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var longevity = await _longevityService.DeleteAsync(id);
            if (longevity == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LongevityDTO longevityDTO)
        {
            if (id == 0 || longevityDTO == null)
                return BadRequest("Id or longevity can be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _longevityService.ExistsAsync(longevityDTO.Name);
            if (exists)
                return Conflict("Longevity already exists.");

            var updatedLongevity = await _longevityService.UpdateAsync(id, longevityDTO);
            if (updatedLongevity == null)
                return NotFound();

            return Ok(updatedLongevity);
        }
    }
}

