using System.ComponentModel.DataAnnotations;

namespace ERP.Areas.Owners.Models
{
    public class ForgetPasswordModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientUrl { get; set; }
    }
}
