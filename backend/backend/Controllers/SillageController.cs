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
                return BadRequest();

            var sillage = await _sillageService.GetAsync(id);
            if (sillage == null)
                return NotFound();

            return Ok(sillage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SillageDTO sillageDTO)
        {
            if (sillageDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDTO = await _sillageService.CreateAsync(sillageDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest();

            var sillage = await _sillageService.DeleteAsync(id);
            if (sillage == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SillageDTO sillageDTO)
        {
            if (id == 0 || sillageDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSillage = await _sillageService.UpdateAsync(id, sillageDTO);
            if (updatedSillage == null)
                return NotFound();

            return Ok(updatedSillage);
        }
    }
}

