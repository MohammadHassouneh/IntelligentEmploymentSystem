using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class CompanyLoginModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
