using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class ResumeModel
    {
        public int ResumeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Experience { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Education { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Skills { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Summary { get; set; }

      
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain digits only")]
        public string Phone { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Address { get; set; }

        public IFormFile? PicPath { get; set; }

        public int UserId { get; set; }

        public string? ImagePath { get; set; }

        public int Score { get; set; }

    }
}
