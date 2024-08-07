using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ScentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ScentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ScentDTO>> GetAllAsync()
        {
            var scents =  await _context.Scents.ToListAsync();
            return _mapper.Map<List<ScentDTO>>(scents);
        }

        public async Task<ScentDTO?> GetAsync(int id)
        {
            var scent = await _context.Scents.FindAsync(id);
            if (scent == null)
                return null;

            return _mapper.Map<ScentDTO>(scent);
        }

        public async Task<ScentDTO> CreateAsync(ScentDTO scentDTO)
        {
            var scent = _mapper.Map<Scent>(scentDTO);
            await _context.Scents.AddAsync(scent);
            await _context.SaveChangesAsync();
            return scentDTO;
        }

        public async Task<Scent?> DeleteAsync(int id)
        {
            var scent = await _context.Scents.FindAsync(id);
            if (scent == null)
                return null;

            _context.Scents.Remove(scent);
            await _context.SaveChangesAsync();
            return scent;
        }

        public async Task<ScentDTO?> UpdateAsync(int id, ScentDTO scentDTO)
        {
            var scent = await _context.Scents.FindAsync(id);
            if (scent == null)
                return null;

            _mapper.Map(scentDTO, scent);
            await _context.SaveChangesAsync();

            return _mapper.Map<ScentDTO>(scent); 
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Scents.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
