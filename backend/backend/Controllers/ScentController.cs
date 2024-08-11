using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScentController : ControllerBase
    {
        private readonly ScentService _scentService;
        public ScentController(ScentService scentService)
        {
            _scentService = scentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scents = await _scentService.GetAllAsync();
            return Ok(scents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var scent = await _scentService.GetAsync(id);
            if (scent == null)
                return NotFound();

            return Ok(scent);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ScentDTO scentDTO)
        {
            if (scentDTO == null)
                return BadRequest("Scent can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _scentService.ExistsAsync(scentDTO.Name);
            if (exists)
                return Conflict("Scent already exists.");

            var createdDTO = await _scentService.CreateAsync(scentDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var scent = await _scentService.DeleteAsync(id);
            if (scent == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ScentDTO scentDTO)
        {
            if (id == 0 || scentDTO == null)
                return BadRequest("Id or scent cant be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _scentService.ExistsAsync(scentDTO.Name);
            if (exists)
                return Conflict("Scent already exists.");

            var updatedScent = await _scentService.UpdateAsync(id, scentDTO);
            if (updatedScent == null)
                return NotFound();

            return Ok(updatedScent);
        }
    }
}
