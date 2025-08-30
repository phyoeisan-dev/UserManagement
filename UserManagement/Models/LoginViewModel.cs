using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
