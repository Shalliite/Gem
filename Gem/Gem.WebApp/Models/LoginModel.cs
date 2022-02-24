using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Enter your email")]

        public string Email { get; set; }
        [Required]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }
    }
}
