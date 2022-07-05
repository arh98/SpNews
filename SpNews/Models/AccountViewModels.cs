using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Models
{
    public class RegisterViewModels
    {
        [Required]
        [MaxLength(60)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Repeat Password")]
        public string RePassword { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [MaxLength(60)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
