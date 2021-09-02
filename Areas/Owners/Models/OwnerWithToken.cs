using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Models
{
    public class OwnerWithToken
    {
        public Owner Owner { get; set; }
        public string Token { get; set; }
    }
}
