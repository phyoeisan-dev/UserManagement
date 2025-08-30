
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Entities;
namespace UserManagement.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser?> LoginAsync(LoginDto dto);
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
