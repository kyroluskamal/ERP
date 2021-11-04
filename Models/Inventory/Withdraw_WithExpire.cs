using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Inventory
{
    public class Withdraw_WithExpire
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required]
        public int Amount { get; set; }

        public Items_withEpire Items_withEpire { get; set; }
        public int Items_withEpireId { get; set; }
    }
}
