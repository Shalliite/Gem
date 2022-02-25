﻿using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [Display(Name = "Enter your email")]
        public string Email { get; set; }
    }
}
