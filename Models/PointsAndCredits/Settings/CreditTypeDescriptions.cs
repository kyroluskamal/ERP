using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.PointsAndCredits.Settings
{
    public class CreditTypeDescriptions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a description")]
        public string Description { get; set; }

        public CreditTypes CreditTypes { get; set; }
        public int CreditTypesId { get; set; }
    }
}
