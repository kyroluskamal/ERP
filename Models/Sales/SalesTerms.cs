using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Sales
{
    public class SalesTerms
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Condtions { get; set; }
    }
}
