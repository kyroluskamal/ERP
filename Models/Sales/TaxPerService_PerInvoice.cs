using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class TaxPerService_PerInvoice
    {
        public int Id { get; set; }

        public TaxSettings TaxSettings { get; set; }
        public int TaxSettingsId { get; set; }

        public ServicesInSalesInvices ServicesInSalesInvices { get; set; }
        public int ServicesInSalesInvicesId { get; set; }
    }
}
