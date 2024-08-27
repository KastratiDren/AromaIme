using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("UserId can't be null or empty.");

            var cart = await _cartService.GetAsync(userId);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("UserId can't be null or empty.");

            var cartDTO = await _cartService.CreateAsync(userId);
            return Ok(cartDTO);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Update([FromRoute] string userId, [FromBody] CartDTO cartDTO)
        {
            if (string.IsNullOrEmpty(userId) || cartDTO == null)
                return BadRequest("UserId or CartDTO can't be null/empty.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCart = await _cartService.UpdateAsync(userId, cartDTO);
            if (updatedCart == null)
                return NotFound();

            return Ok(updatedCart);
        }

        [HttpGet("exists/{userId}")]
        public async Task<IActionResult> CartExists([FromRoute] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("UserId can't be null or empty.");

            var exists = await _cartService.CartExistsAsync(userId);
            return Ok(new { Exists = exists });
        }
    }
}
