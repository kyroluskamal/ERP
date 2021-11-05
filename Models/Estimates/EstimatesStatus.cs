using ERP.Models.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Estimates
{
    public class EstimatesStatus
    {
        public int Id { get; set; }

        public Status Status { get; set; }
        public int? Status { get; set; }
        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
