namespace ERP.Models
{
    public class SendEmailConfirmationAgian
    {
        public string Email { get; set; }
        public string ClientUrl { get; set; }
        public string Subdomain { get; set; }
        public bool IsCOC { get; set; }
    }
}
