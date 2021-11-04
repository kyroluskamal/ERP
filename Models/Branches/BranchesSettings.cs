using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Branches
{
    public class BranchesSettings
    {
        public int Id { get; set; }
        [Column(TypeName = "bit")]
        public bool IsCostCentersShared { get; set; }

        [Column(TypeName = "bit")]
        public bool IsClientShared { get; set; }

        [Column(TypeName = "bit")]
        public bool IsProducShared { get; set; }

        [Column(TypeName = "bit")]
        public bool IsSupplierShared { get; set; }

        [Column(TypeName = "bit")]
        public bool SpcifyAccountbranches { get; set; }

        [ForeignKey(nameof(BranchId))]
        public BusinessBranches BusinessBranches { get; set; }
        public int BranchId { get; set; }
    }
}
