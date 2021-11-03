using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Items
{
    public class Brands
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the brand name")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
