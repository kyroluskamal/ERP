using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Estimates
{
    public class EstimatesNotes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
