using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Wrong Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Wrong Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
