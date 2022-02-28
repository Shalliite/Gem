using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Models
{
    public class RegistrationConfirmationModel
    {
        [Required]
        [Display(Name = "Enter 6-digit confirmation code")]
        public string VerificationCode { get; set; }
    }
}
