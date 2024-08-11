using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories =  await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            return category;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return categoryDTO;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryDTO?> UpdateAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            _mapper.Map(categoryDTO, category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(category); 
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Categories.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
