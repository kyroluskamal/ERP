using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Supplier
{
    public class Supplier_notes
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Note { get; set; }

        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
