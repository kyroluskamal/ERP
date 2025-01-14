﻿using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Inventory
{
    public class InboundNotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }

        public Inbound_Invent_Requisitions Inbound_Invent_Requisitions { get; set; }
        public int Inbound_Invent_RequisitionsId { get; set; }
    }
}
