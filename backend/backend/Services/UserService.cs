using AutoMapper;
using backend.Data;
using backend.DTOs.UserDTOs;
using backend.Models; // Make sure to include this if your models are in this namespace
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager; 

        public UserService(AppDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        // Helper method to get the role of a user
        private async Task<string> GetUserRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault() ?? string.Empty;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            var userDTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                userDTO.Role = await GetUserRoleAsync(user); 
                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<UserDTO?> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Role = await GetUserRoleAsync(user);
            return userDTO;
        }


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
