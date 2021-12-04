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
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Actions { get; set; }
        public Appointments Appointments { get; set; }
        public int AppointmentsId { get; set; }
    }
}
