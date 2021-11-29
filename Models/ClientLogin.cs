using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ClientLogin
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Subdomain { get; set; }
        public bool IsCOC { get; set; }
    }
}
