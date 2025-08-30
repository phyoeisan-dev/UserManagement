using Microsoft.AspNetCore.Identity;
namespace UserManagement.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ContactNo { get; set; }
        public string NRCNo { get; set; } = string.Empty;
    }
}
