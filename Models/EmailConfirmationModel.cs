using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class EmailConfirmationModel
    {
        public string email { get; set; }
        public string token { get; set; }
    }
}
