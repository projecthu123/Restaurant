using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Wrong Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Wrong Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Wrong Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password not match")]
        public String ConfirmPassword { get; set; }

    }
}
