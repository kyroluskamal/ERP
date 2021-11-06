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
