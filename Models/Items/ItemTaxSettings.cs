using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class ItemTaxSettings
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public TaxSettings TaxSettings { get; set; }
        public int? TaxSettingsId { get; set; }
    }
}
