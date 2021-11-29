using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ClientForgetPasswordModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientUrl { get; set; }
        public string Subdomain { get; set; }
        public bool IsCOC { get; set; }
    }
}
