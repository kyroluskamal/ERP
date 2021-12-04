using ERP.Models.CutomFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.Settings
{
    public class SalesInvoices_CustomFields
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public string Value { get; set; }

        public SalesInvoices SalesInvoices { get; set; }
        public int SalesInvoicesId { get; set; }

        public Fields_Per_Service Fields_Per_Service { get; set; }
        public int Fields_Per_ServiceId { get; set; }
    }
}
