using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CRMSystem
{
    public class Appointments_Notes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Notes { get; set; }
        public Appointments Appointments { get; set; }
        public int AppointmentsId { get; set; }
    }
}
