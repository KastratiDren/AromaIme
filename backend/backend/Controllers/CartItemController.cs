using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _cartItemService;

        public CartItemController(CartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than zero.");

            var cartItem = await _cartItemService.GetAsync(id);
            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CartItemDTO cartItemDTO)
        {
            if (cartItemDTO == null)
                return BadRequest("CartItemDTO can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCartItemDTO = await _cartItemService.CreateAsync(cartItemDTO);
            if (createdCartItemDTO == null)
                return NotFound("Cart or Fragrance not found.");

            return Ok(createdCartItemDTO);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CartItemDTO cartItemDTO)
        {
            if (id <= 0 || cartItemDTO == null)
                return BadRequest("Id must be greater than zero and CartItemDTO can't be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCartItemDTO = await _cartItemService.UpdateAsync(id, cartItemDTO);
            if (updatedCartItemDTO == null)
                return NotFound();

            return Ok(updatedCartItemDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than zero.");

            var deletedCartItem = await _cartItemService.DeleteAsync(id);
            if (deletedCartItem == null)
                return NotFound();

            return NoContent();
        }
    }
}
