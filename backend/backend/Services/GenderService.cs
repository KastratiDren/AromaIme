using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class GenderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GenderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GenderDTO>> GetAllAsync()
        {
            var genders =  await _context.Genders.ToListAsync();
            return _mapper.Map<List<GenderDTO>>(genders);
        }

        public async Task<GenderDTO?> GetAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
                return null;

            return _mapper.Map<GenderDTO>(gender);
        }

        public async Task<GenderDTO> CreateAsync(GenderDTO genderDTO)
        {
            var gender = _mapper.Map<Gender>(genderDTO);
            await _context.Genders.AddAsync(gender);
            await _context.SaveChangesAsync();
            return genderDTO;
        }

        public async Task<Gender?> DeleteAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
                return null;

            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<GenderDTO?> UpdateAsync(int id, GenderDTO genderDTO)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
                return null;

            _mapper.Map(genderDTO, gender);
            await _context.SaveChangesAsync();

            return _mapper.Map<GenderDTO>(gender); 
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Genders.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
