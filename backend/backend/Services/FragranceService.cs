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

        public async Task<List<FragranceDto>> GetAllAsync()
        {
            var fragrances = await _context.Fragrances.ToListAsync();
            return _mapper.Map<List<FragranceDto>>(fragrances);
        }

        public async Task<FragranceDto?> GetAsync(int id)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
                return null;

            return _mapper.Map<FragranceDto>(fragrance);
        }

        public async Task<FragranceDto> CreateAsync(FragranceDto fragranceDto)
        {
            var fragrance = _mapper.Map<Fragrance>(fragranceDto);
            await _context.Fragrances.AddAsync(fragrance);
            await _context.SaveChangesAsync();
            return fragranceDto;
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

        public async Task<FragranceDto?> UpdateAsync(int id, FragranceDto fragranceDto)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
                return null;

            _mapper.Map(fragranceDto, fragrance);
            await _context.SaveChangesAsync();

            return _mapper.Map<FragranceDto>(fragrance);
        }
    }
}

