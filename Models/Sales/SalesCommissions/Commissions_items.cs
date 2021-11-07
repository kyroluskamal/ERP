using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class Commissions_items
    {
        public int Id { get; set; }

        public Commissions Commissions { get; set; }
        public int CommissionsId { get; set; }

        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
