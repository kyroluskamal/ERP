using ERP.Models.Items;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class TransferBetweenInvent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string CurrentNumber { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int ToInventoryId { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int FromInventoryId { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public int AmountTransfered { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
