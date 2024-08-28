using AutoMapper;
using backend.Data;
using backend.DTOs.UserDTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Method to get all users
        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        // Method to get a single user by id
        public async Task<UserDTO?> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            return _mapper.Map<UserDTO>(user);
        }

        // Method to delete a user by id
        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
