using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ClientForgetPasswordModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientUrl { get; set; }
    }
}
