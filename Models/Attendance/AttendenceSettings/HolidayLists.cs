using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class HolidayLists
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name for the holidaies list")]
        public string Name { get; set; }
    }
}
