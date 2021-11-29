namespace ERP.Models
{
    public class EmailConfirmationModel
    {
        public string email { get; set; }
        public string token { get; set; }
        public string Subdomain { get; set; }
        public bool IsCOC { get; set; }
    }
}
