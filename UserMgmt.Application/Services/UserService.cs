using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using UserManagement.Domain.DTOs;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null) return null;


            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            return result.Succeeded ? user : null;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword) return false;


            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                ContactNo = dto.ContactNo,
                NRCNo = dto.NrcNo
            };


            var result = await _userManager.CreateAsync(user, dto.Password);
            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return false;


            if (dto.NewPassword != dto.ConfirmPassword) return false;


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
            return result.Succeeded;
        }


    }
}
