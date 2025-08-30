using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

    }
}
