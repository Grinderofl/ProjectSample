using System.ComponentModel.DataAnnotations;

namespace ProjectSample.Areas.Account.Models.Login
{
    public class LoginFields
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}