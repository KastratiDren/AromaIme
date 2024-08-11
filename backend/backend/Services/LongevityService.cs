using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class LongevityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public LongevityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Longevity>> GetAllAsync()
        {
            var longevities =  await _context.Longevities.ToListAsync();
            return longevities;
        }

        public async Task<Longevity?> GetAsync(int id)
        {
            var longevity = await _context.Longevities.FindAsync(id);
            if (longevity == null)
                return null;

            return longevity;
        }

        public async Task<LongevityDTO> CreateAsync(LongevityDTO longevityDTO)
        {
            var longevity = _mapper.Map<Longevity>(longevityDTO);
            await _context.Longevities.AddAsync(longevity);
            await _context.SaveChangesAsync();
            return longevityDTO;
        }

        public async Task<Longevity?> DeleteAsync(int id)
        {
            var longevity = await _context.Longevities.FindAsync(id);
            if (longevity == null)
                return null;

            _context.Longevities.Remove(longevity);
            await _context.SaveChangesAsync();
            return longevity;
        }

        public async Task<LongevityDTO?> UpdateAsync(int id, LongevityDTO longevityDTO)
        {
            var longevity = await _context.Longevities.FindAsync(id);
            if (longevity == null)
                return null;

            _mapper.Map(longevityDTO, longevity);
            await _context.SaveChangesAsync();

            return _mapper.Map<LongevityDTO>(longevity); 
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Longevities.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
