using System.Collections.Generic;

namespace ERP.Models
{
    public class ClientWithToken
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public string Subdomain { get; set; }
    }
}
