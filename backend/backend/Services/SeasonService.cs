using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SeasonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SeasonService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SeasonDTO>> GetAllAsync()
        {
            var seasons =  await _context.Seasons.ToListAsync();
            return _mapper.Map<List<SeasonDTO>>(seasons);
        }

        public async Task<SeasonDTO?> GetAsync(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
                return null;

            return _mapper.Map<SeasonDTO>(season);
        }

        public async Task<SeasonDTO> CreateAsync(SeasonDTO seasonDTO)
        {
            var season = _mapper.Map<Season>(seasonDTO);
            await _context.Seasons.AddAsync(season);
            await _context.SaveChangesAsync();
            return seasonDTO;
        }

        public async Task<Season?> DeleteAsync(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
                return null;

            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();
            return season;
        }

        public async Task<SeasonDTO?> UpdateAsync(int id, SeasonDTO seasonDTO)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
                return null;

            _mapper.Map(seasonDTO, season);
            await _context.SaveChangesAsync();

            return _mapper.Map<SeasonDTO>(season); 
        }

    }
}
