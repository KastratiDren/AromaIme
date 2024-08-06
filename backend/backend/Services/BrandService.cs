using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class BrandService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BrandService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BrandDTO>> GetAllAsync()
        {
            var brands =  await _context.Brands.ToListAsync();
            var brandsDTO = _mapper.Map<List<BrandDTO>>(brands);
            return brandsDTO;
        }

        public async Task<BrandDTO?> GetAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return null;
            }

            var brandDTO = _mapper.Map<BrandDTO>(brand);
            return brandDTO;
        }

        public async Task<BrandDTO> CreateAsync(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brandDTO;
        }

        public async Task<Brand?> DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return null;

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandDTO?> UpdateAsync(int id, BrandDTO brandDTO)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return null;

            _mapper.Map(brandDTO, brand);
            await _context.SaveChangesAsync();

            return _mapper.Map<BrandDTO>(brand); 
        }

    }
}
