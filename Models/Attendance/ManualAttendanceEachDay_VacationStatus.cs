using ERP.Models.Attendance.AttendenceSettings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance
{
    public class ManualAttendanceEachDay_VacationStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "smallint")]
        public int VacationCount { get; set; }

        public VacationsType_LeaveType VacationsType_LeaveType { get; set; }
        public int VacationsType_LeaveTypeId { get; set; }
        public ManualAttendanceEachDay ManualAttendenceEachDay { get; set; }
        public int ManualAttendenceEachDayId { get; set; }
    }
}
