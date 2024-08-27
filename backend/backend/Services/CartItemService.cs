using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CartItemService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CartItemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartItemDTO?> GetAsync(int id)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Fragrance)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (cartItem == null)
                return null;

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async Task<CartItemDTO?> CreateAsync(CartItemDTO cartItemDTO)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDTO);

            // Check if the cart exists
            var cart = await _context.Carts.FindAsync(cartItem.CartId);
            if (cart == null)
                return null;

            // Check if the fragrance exists
            var fragrance = await _context.Fragrances.FindAsync(cartItem.FragranceId);
            if (fragrance == null)
                return null;

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async Task<CartItemDTO?> UpdateAsync(int id, CartItemDTO cartItemDTO)
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Fragrance)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (cartItem == null)
                return null;

            _mapper.Map(cartItemDTO, cartItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async Task<CartItem?> DeleteAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
                return null;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }
    }
}
