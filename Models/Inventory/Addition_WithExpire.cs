using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Inventory
{
    public class Addition_WithExpire
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required_field")]
        public int Amount { get; set; }

        public Items_withEpire Items_withEpire { get; set; }
        public int Items_withEpireId { get; set; }
    }
}
