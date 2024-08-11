using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SillageController : ControllerBase
    {
        private readonly SillageService _sillageService;
        public SillageController(SillageService sillageService)
        {
            _sillageService = sillageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sillages = await _sillageService.GetAllAsync();
            return Ok(sillages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var sillage = await _sillageService.GetAsync(id);
            if (sillage == null)
                return NotFound();

            return Ok(sillage);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SillageDTO sillageDTO)
        {
            if (sillageDTO == null)
                return BadRequest("Sillage can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _sillageService.ExistsAsync(sillageDTO.Name);
            if (exists)
                return Conflict("Sillage already exists.");

            var createdDTO = await _sillageService.CreateAsync(sillageDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var sillage = await _sillageService.DeleteAsync(id);
            if (sillage == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SillageDTO sillageDTO)
        {
            if (id == 0 || sillageDTO == null)
                return BadRequest("Id or sillage can't be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _sillageService.ExistsAsync(sillageDTO.Name);
            if (exists)
                return Conflict("Sillage already exists.");

            var updatedSillage = await _sillageService.UpdateAsync(id, sillageDTO);
            if (updatedSillage == null)
                return NotFound();

            return Ok(updatedSillage);
        }
    }
}

