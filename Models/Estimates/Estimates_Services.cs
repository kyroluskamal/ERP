using ERP.Models.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Estimates
{
    public class Estimates_Services
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Money")]
        public decimal NewPrice { get; set; }

        public Services Services { get; set; }
        public int? ServicesId { get; set; }
        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
