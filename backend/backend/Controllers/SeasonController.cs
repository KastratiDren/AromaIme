using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly SeasonService _seasonService;
        public SeasonController(SeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seasons = await _seasonService.GetAllAsync();
            return Ok(seasons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be zero.");

            var season = await _seasonService.GetAsync(id);
            if(season == null)
                return NotFound();

            return Ok(season);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SeasonDTO seasonDTO)
        {
            if(seasonDTO == null)
                return BadRequest("Scent can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _seasonService.ExistsAsync(seasonDTO.Name);
            if (exists)
                return Conflict("Season already exists.");

            var createdDTO = await _seasonService.CreateAsync(seasonDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id == 0) 
                return BadRequest("Id can't be zero.");

            var season = await _seasonService.DeleteAsync(id);
            if (season == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SeasonDTO seasonDTO)
        {
            if (id == 0 || seasonDTO == null)
                return BadRequest("Id or season can't be zero/null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _seasonService.ExistsAsync(seasonDTO.Name);
            if (exists)
                return Conflict("Season already exists.");

            var updatedSeason = await _seasonService.UpdateAsync(id, seasonDTO);
            if (updatedSeason == null)
                return NotFound();

            return Ok(updatedSeason);
        }


    }
}
