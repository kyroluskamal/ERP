using ERP.Models.Generals;

namespace ERP.Models.Estimates
{
    public class EstimatesStatus
    {
        public int Id { get; set; }

        public Status Status { get; set; }
        public int? StatusId { get; set; }
        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
