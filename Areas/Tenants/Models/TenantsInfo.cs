using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Areas.Tenants.Models
{
    public class TenantsInfo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        [Index(IsUnique = true)]
        public string Subdomain { get; set; }
        
        public string ConnectionString { get; set; }
    }
}
