using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ClientResetPasswordModel
    {
        public string email { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
