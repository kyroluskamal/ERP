﻿namespace ERP.Models.Estimates
{
    public class EstimatesAttachments
    {
        public int Id { get; set; }
        public byte[] Attachment { get; set; }

        public Estimate Estimate { get; set; }
        public int EstimateId { get; set; }
    }
}
