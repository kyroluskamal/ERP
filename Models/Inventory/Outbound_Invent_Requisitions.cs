using ERP.Models.Items;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Outbound_Invent_Requisitions
    {
        public int Id { get; set; }
        [Required]
        public string CurrentNumber { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }

        public Inventories Inventory { get; set; }
        public int InventoryId { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
