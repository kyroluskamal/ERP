using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.COC
{
    public class COC_category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You need to specify a category name")]
        [MaxLength(15)]
        public string CategoryName { get; set; }
    }
}
