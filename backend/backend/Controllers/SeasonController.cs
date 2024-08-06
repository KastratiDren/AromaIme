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
                return BadRequest();

            var season = await _seasonService.GetAsync(id);
            if(season == null)
                return NotFound();

            return Ok(season);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeasonDTO seasonDTO)
        {
            if(seasonDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDTO = await _seasonService.CreateAsync(seasonDTO);
            return Ok(createdDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id == 0)
                return BadRequest();

            var season = await _seasonService.DeleteAsync(id);
            if (season == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SeasonDTO seasonDTO)
        {
            if (id == 0 || seasonDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSeason = await _seasonService.UpdateAsync(id, seasonDTO);
            if (updatedSeason == null)
                return NotFound();

            return Ok(updatedSeason);
        }


    }
}
