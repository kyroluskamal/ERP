using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class AttendanceSettings
    {
        public int Id { get; set; }
        [Column(TypeName = "bit")]
        public bool EnableSecondryShift { get; set; }
        [Column(TypeName = "tinyint")]
        public int FiscalYearStartMonth { get; set; }
        [Column(TypeName = "tinyint")]
        public int FiscalYearStartDay { get; set; }
    }
}
