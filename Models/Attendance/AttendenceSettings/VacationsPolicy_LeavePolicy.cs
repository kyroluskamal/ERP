using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class VacationsPolicy_LeavePolicy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
