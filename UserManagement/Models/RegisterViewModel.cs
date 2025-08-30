using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        public string? ContactNo { get; set; }

        [Required]
        public string? NRCNo { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
