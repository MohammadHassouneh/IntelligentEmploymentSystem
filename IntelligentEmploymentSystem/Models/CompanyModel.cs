using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class CompanyModel
    {

        public int CompanyId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string AboutUs { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string OurService { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Phone { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string WebSite { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Address { get; set; } 

    }
}
