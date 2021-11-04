using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Inventory
{
    public class InboundNotes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public Inbound_Invent_Requisitions Inbound_Invent_Requisitions { get; set; }
        public int Inbound_Invent_RequisitionsId { get; set; }
    }
}
