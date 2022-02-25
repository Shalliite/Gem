using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem.WebApp.Models
{
    public class RegistrationModel : BasePasswordModel
    {
        [Required]
        [RegularExpression("[a-zA-Z/'/-]+", ErrorMessage = "Enter valid first name. Allowed characters: (A-z).")]
        [MaxLength(30, ErrorMessage = "Maximum name length is 30 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression("[a-zA-Z/'/-]+", ErrorMessage = "Enter valid middle name. Allowed characters: (A-z).")]
        [MaxLength(30, ErrorMessage = "Maximum name length is 30 characters.")]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z/'/-]+", ErrorMessage = "Enter valid last name. Allowed characters: (A-z).")]
        [MaxLength(30, ErrorMessage = "Maximum name length is 30 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Enter valid e-mail address.")]
        [MaxLength(50, ErrorMessage = "Maximum e-mail length is 50 characters.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
