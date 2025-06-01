using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace IntelligentEmploymentSystem.Models
{
    public class UserModel
    {
        public int userId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name is required")]
        public string userName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).+$",
         ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character")]
        public string password { get; set; }

    
    }
}

