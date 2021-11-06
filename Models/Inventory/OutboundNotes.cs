using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class OutboundNotes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public Outbound_Invent_Requisitions Outbound_Invent_Requisitions { get; set; }
        public int Outbound_Invent_RequisitionsId { get; set; }
    }
}
