using ERP.Models.PointsAndCredits;
using ERP.Models.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Membership
{
    public class Memberships
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Required]
        public int ToleranceDays { get; set; }

        [Column(TypeName = "bit")]
        public bool HasDescription { get; set; }

        public ERP.Models.COC.COC COC { get; set; }
        public int COCId { get; set; }

        public Packages Packages { get; set; }
        public int PackagesId { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int? SalesInvoicesId { get; set; }
    }
}
