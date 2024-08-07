using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SillageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SillageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SillageDTO>> GetAllAsync()
        {
            var sillages =  await _context.Sillages.ToListAsync();
            return _mapper.Map<List<SillageDTO>>(sillages);
        }

        public async Task<SillageDTO?> GetAsync(int id)
        {
            var sillage = await _context.Sillages.FindAsync(id);
            if (sillage == null)
                return null;

            return _mapper.Map<SillageDTO>(sillage);
        }

        public async Task<SillageDTO> CreateAsync(SillageDTO sillageDTO)
        {
            var sillage = _mapper.Map<Sillage>(sillageDTO);
            await _context.Sillages.AddAsync(sillage);
            await _context.SaveChangesAsync();
            return sillageDTO;
        }

        public async Task<Sillage?> DeleteAsync(int id)
        {
            var sillage = await _context.Sillages.FindAsync(id);
            if (sillage == null)
                return null;

            _context.Sillages.Remove(sillage);
            await _context.SaveChangesAsync();
            return sillage;
        }

        public async Task<SillageDTO?> UpdateAsync(int id, SillageDTO sillageDTO)
        {
            var sillage = await _context.Sillages.FindAsync(id);
            if (sillage == null)
                return null;

            _mapper.Map(sillageDTO, sillage);
            await _context.SaveChangesAsync();

            return _mapper.Map<SillageDTO>(sillage); 
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Sillages.AnyAsync(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}
