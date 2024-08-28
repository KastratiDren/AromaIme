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
        private readonly UserService _userService;

        public CartController(CartService cartService, UserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("UserId can't be null or empty.");

            var user = await _userService.GetAsync(userId);
            if (user == null)
                return NotFound("User doesn't exist!");

            var cart = await _cartService.GetAsync(userId);
            if (cart == null)
                return NotFound("Cart doesn't exist!");

            return Ok(cart);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("UserId can't be null or empty.");

            var user = await _userService.GetAsync(userId);
            if (user == null)
                return NotFound("User doesn't exist!");

            var cartDTO = await _cartService.CreateAsync(userId);
            return Ok(cartDTO);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Update([FromRoute] string userId, [FromBody] CartDTO cartDTO)
        {
            if (string.IsNullOrEmpty(userId) || cartDTO == null)
                return BadRequest("UserId or CartDTO can't be null/empty.");

            if (userId != cartDTO.UserId)
                return BadRequest("The id doesnt match!");

            var user = await _userService.GetAsync(userId);
            if (user == null)
                return NotFound("User doesn't exist!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCart = await _cartService.UpdateAsync(userId, cartDTO);
            if (updatedCart == null)
                return NotFound();

            return Ok(updatedCart);
        }

        [HttpGet("exists/{id}")]
        public async Task<IActionResult> CartExists([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("Id can't be null or empty.");

            var exists = await _cartService.CartExistsAsync(id);
            return Ok(new { Exists = exists });
        }
    }
}
