using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class TaxPer_Item_PerInvoice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int TaxValue { get; set; }

        public TaxSettings TaxSettings { get; set; }
        public int TaxSettingsId { get; set; }

        public ItemsInSalesInvoices ItemsInSalesInvoices { get; set; }
        public int ItemsInSalesInvoicesId { get; set; }
    }
}
