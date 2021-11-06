using ERP.Models.PointsAndCredits.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits
{
    public class Packages_CreditType
    {
        public int Id { get; set; }
        [Required]
        public int CreditAmount { get; set; }
        public CreditTypes CreditTypes { get; set; }
        public int CreditTypesId { get; set; }
        public Packages Packages { get; set; }
        public int PackagesId { get; set; }
    }
}
