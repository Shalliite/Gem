using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Models
{
    public class ResetPasswordModel : BasePasswordModel
    {
        [Required]
        [Display(Name = "Enter 6-digit verification code")]
        public string VerificationCode { get; set; }
    }
}
