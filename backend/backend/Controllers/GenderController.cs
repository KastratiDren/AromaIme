using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly GenderService _genderService;
        public GenderController(GenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genders = await _genderService.GetAllAsync();
            return Ok(genders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var gender = await _genderService.GetAsync(id);
            if (gender == null)
                return NotFound();

            return Ok(gender);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] GenderDTO genderDTO)
        {
            if (genderDTO == null)
                return BadRequest("Gender can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _genderService.ExistsAsync(genderDTO.Name);
            if (exists)
                return Conflict("Gender already exists.");

            var createdDTO = await _genderService.CreateAsync(genderDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var gender = await _genderService.DeleteAsync(id);
            if (gender == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GenderDTO genderDTO)
        {
            if (id == 0 || genderDTO == null)
                return BadRequest("Id or gender can't be zero/null.");

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            bool exists = await _genderService.ExistsAsync(genderDTO.Name);
            if (exists)
                return Conflict("Gender already exists.");

            var updatedGender = await _genderService.UpdateAsync(id, genderDTO);
            if (updatedGender == null)
                return NotFound();

            return Ok(updatedGender);
        }
    }
}

