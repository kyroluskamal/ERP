using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class OwnerRegister
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Your Username is required")]
        public string UserName { get; set; }
        public string ClientUrl { get; set; }
        [Required(ErrorMessage = "You first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You last name is required")]
        public string LastName { get; set; }
    }
}
