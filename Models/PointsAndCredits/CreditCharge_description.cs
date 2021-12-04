using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits
{
    public class CreditCharge_description
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Description { get; set; }
        public CreditCharge CreditCharge { get; set; }
        public int CreditChargeId { get; set; }
    }
}
