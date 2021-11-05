using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Estimates
{
    public class EstimatesShippingFees
    {
        public int Id { get; set; }
        public int ShippingFees { get; set; }

        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
