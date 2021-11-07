using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class CommissionsNotes
    {
        public int Id { get; set; }

        [Required]
        public string Notes { get; set; }

        public Commissions Commissions { get; set; }
        public int CommissionsId { get; set; }
    }
}
