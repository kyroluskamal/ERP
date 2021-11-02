using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Generals
{
    public class WhenRemidersSent
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You need to add option")]
        public string WhenOption { get; set; }
    }
}
