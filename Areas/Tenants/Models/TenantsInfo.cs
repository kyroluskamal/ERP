using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Areas.Tenants.Models
{
    public class TenantsInfo
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Subdomain { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string ConnectionString { get; set; }
    }
}
