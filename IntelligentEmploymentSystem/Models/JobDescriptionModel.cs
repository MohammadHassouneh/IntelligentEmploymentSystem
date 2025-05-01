using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class JobDescriptionModel
    {

        public int JobDescriptionId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string JobBrief { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Responsibilities { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Requirements { get; set; } 

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Status { get; set; }
    }
}
