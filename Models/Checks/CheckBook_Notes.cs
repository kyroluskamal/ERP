using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Checks
{
    public class CheckBook_Notes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public CheckBook CheckBook { get; set; }
        public int CheckBookId { get; set; }
    }
}
