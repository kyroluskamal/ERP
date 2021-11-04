using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Service
{
    public class ServiceTaxSettings
    {
        public int Id { get; set; }
        public Services Service { get; set; }
        public int ServiceId { get; set; }
        public TaxSettings TaxSettings { get; set; }
        public int? TaxSettingsId { get; set; }
    }
}
