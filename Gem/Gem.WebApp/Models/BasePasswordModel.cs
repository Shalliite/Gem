using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Models
{
    public abstract class BasePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "Password should be 8-18 characters long.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
