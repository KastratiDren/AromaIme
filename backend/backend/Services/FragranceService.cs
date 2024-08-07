using AutoMapper;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class FragranceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FragranceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FragranceDTO>> GetAllAsync()
        {
            var fragrances = await _context.Fragrances.ToListAsync();
            return _mapper.Map<List<FragranceDTO>>(fragrances);
        }

        public async Task<FragranceDTO?> GetAsync(int id)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
                return null;

            return _mapper.Map<FragranceDTO>(fragrance);
        }

        public async Task<FragranceDTO> CreateAsync(FragranceDTO fragranceDTO)
        {
            var fragrance = _mapper.Map<Fragrance>(fragranceDTO);
            await _context.Fragrances.AddAsync(fragrance);
            await _context.SaveChangesAsync();
            return fragranceDTO;
        }

        public async Task<Fragrance?> DeleteAsync(int id)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
                return null;

            _context.Fragrances.Remove(fragrance);
            await _context.SaveChangesAsync();
            return fragrance;
        }

        public async Task<FragranceDTO?> UpdateAsync(int id, FragranceDTO fragranceDTO)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
                return null;

            _mapper.Map(fragranceDTO, fragrance);
            await _context.SaveChangesAsync();

            return _mapper.Map<FragranceDTO>(fragrance);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Fragrances.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}

