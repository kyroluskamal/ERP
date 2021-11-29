using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ClientResetPasswordModel
    {
        public string email { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "ConfirmPasswordNoPassswordMatch")]
        public string ConfirmPassword { get; set; }
        public string Subdomain { get; set; }
        public bool IsCOC { get; set; }
    }
}
