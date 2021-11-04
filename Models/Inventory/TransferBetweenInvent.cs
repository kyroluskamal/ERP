using ERP.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Inventory
{
    public class TransferBetweenInvent
    {
        public int Id { get; set; }
        [Required]
        public string CurrentNumber { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        [Required]
        public int ToInventoryId { get; set; }
        [Required]
        public int FromInventoryId { get; set; }
        [Required]
        public int AmountTransfered { get; set; }
        public ItemVariants ItemVariants { get; set; }
        public int ItemVariantsId { get; set; }
    }
}
