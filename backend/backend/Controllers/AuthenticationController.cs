﻿using api.Service;
using backend.DTOs.UserDTOs;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private readonly AuthenticationService _authenticationService;
        public AuthenticationController(UserManager<User> userManager, AuthenticationService authenticationService, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _signinManager = signinManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(
                new UserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _authenticationService.CreateToken(user),
                    Role = roles.FirstOrDefault()
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User
                {
                    Name = registerDTO.Name,
                    Surname = registerDTO.Surname,
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email
                };

                var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        return Ok(
                            new UserDTO
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _authenticationService.CreateToken(user),
                                Role = roles.FirstOrDefault()
                            }
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signinManager.SignOutAsync();
                return Ok("User logged out successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
