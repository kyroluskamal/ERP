using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales.SalesCommissions
{
    public class Commissions_SerCat
    {
        public int Id { get; set; }

        public Commissions Commissions { get; set; }
        public int CommissionsId { get; set; }

        public ServiceSubCategory ServiceSubCategory { get; set; }
        public int ServiceSubCategoryId { get; set; }
    }
}
