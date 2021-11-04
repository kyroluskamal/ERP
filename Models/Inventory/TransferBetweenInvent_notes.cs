using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Inventory
{
    public class TransferBetweenInvent_notes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public TransferBetweenInvent TransferBetweenInvent { get; set; }
        public int TransferBetweenInventId { get; set; }
    }
}
