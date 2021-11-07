using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class Commissions_ItemCat
    {
        public int Id { get; set; }

        public Commissions Commissions { get; set; }
        public int CommissionsId { get; set; }

        public ItemSubCategory ItemSubCategory { get; set; }
        public int ItemSubCategoryId { get; set; }
    }
}
