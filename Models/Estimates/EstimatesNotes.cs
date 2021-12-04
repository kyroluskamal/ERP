using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Estimates
{
    public class EstimatesNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
