using ERP.Areas.Owners.Models.Identity;
using System.Collections.Generic;

namespace ERP.Areas.Owners.Models
{
    public class OwnerWithToken
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
       
    }
}
