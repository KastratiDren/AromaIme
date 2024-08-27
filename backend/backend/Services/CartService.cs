using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CartService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CartService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDTO?> GetAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Fragrance)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return null;

            var cartDTO = _mapper.Map<CartDTO>(cart);
            return cartDTO;
        }

        public async Task<CartDTO> CreateAsync(string userId)
        {
            var cart = new Cart
            {
                UserId = userId,
                TotalAmount = 0 // Initialize total amount to 0
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<CartDTO?> UpdateAsync(string userId, CartDTO cartDTO)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return null;

            _mapper.Map(cartDTO, cart);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<bool> CartExistsAsync(string userId)
        {
            return await _context.Carts.AnyAsync(c => c.UserId == userId);
        }
    }
}
