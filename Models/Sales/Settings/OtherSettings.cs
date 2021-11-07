using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.Settings
{
    public class OtherSettings
    {
        public int Id { get; set; }
        [Column(TypeName = "bit")]
        public bool Disable_Edit_PerItem_InInvoice { get; set; }
        [Column(TypeName = "bit")]
        public bool DisableEstimateModule { get; set; }
        [Column(TypeName = "bit")]
        public bool IsManualInvoiceNumber { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableInvoiceManualStatus { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableEstimateManualStatus { get; set; }
        [Column(TypeName = "bit")]
        public bool AutoPayFromBalance { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableMaximumDiscount { get; set; }
        public int MaximumDiscount { get; set; }
    }
}
