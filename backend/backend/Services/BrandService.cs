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
            return _mapper.Map<List<BrandDTO>>(brands);
        }

        public async Task<BrandDTO?> GetAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return null;

            return _mapper.Map<BrandDTO>(brand);
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

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Brands.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
