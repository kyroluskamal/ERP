using System.Collections.Generic;

namespace ERP.Models
{
    public class UserWithToken
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public string Subdomain { get; set; }
    }
}
