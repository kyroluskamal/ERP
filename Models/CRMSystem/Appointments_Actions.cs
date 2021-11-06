using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.CRMSystem
{
    public class Appointments_Actions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, add an action")]
        [MaxLength(30)]
        public string Actions { get; set; }
        public Appointments Appointments { get; set; }
        public int AppointmentsId { get; set; }
    }
}
