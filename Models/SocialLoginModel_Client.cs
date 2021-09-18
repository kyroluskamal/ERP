using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class SocialLoginModel_Client
    {
        public string provider { get; set; }
        public string Id { get; set; }
        public string email { get; set; }
        public string name{ get; set; }
        public string photoUrl{ get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string authToken { get; set; }
        public string idToken { get; set; }
        public string authorizationCode { get; set; }
        public string response { get; set; }
    }
}
