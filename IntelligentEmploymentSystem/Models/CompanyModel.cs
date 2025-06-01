using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string AboutUs { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string OurService { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain digits only")]
        public string Phone { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [Url(ErrorMessage = "Invalid website URL")]
        public string WebSite { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Address { get; set; }
    }
}
