using ERP.Models.Employee;
using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class Commissions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Name { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column(TypeName = "bit")]
        public bool TargetType { get; set; } //revenue or volume

        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        [Column(TypeName = "tinyint")]
        public int ForCatOrItemOrService { get; set; }

        [Column(TypeName = "tinyint")]
        public int CommissionPeriod { get; set; }

        [Column(TypeName = "tinyint")]
        public int CalculationType { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public int Percent { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }

        public string Currency { get; set; }
        public int CurrencyId { get; set; }

        [ForeignKey(nameof(AddedBy_EmpId))]
        public Employees Employees { get; set; }
        public int AddedBy_EmpId { get; set; }
    }
}
