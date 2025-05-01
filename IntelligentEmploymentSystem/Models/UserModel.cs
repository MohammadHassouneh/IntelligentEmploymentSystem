using System.ComponentModel.DataAnnotations;

namespace IntelligentEmploymentSystem.Models
{
    public class UserModel
    {
        public int uesrId { get; set; }

        [Required (AllowEmptyStrings =false, ErrorMessage = "This field is required")] 
        public string userName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string password { get; set; }



    }
}
