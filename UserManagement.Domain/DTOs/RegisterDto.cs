using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.DTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ContactNo { get; set; }
        public string NrcNo { get; set; } = string.Empty;
    }
}
