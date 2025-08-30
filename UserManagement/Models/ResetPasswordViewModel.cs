using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
