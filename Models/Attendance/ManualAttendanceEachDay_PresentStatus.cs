using ERP.Models.Attendance.AttendenceSettings;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance
{
    public class ManualAttandanceEachDay_PresentStatus
    {
        public int Id { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan OnDutyTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan OffDutyTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan SignInTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan SignOutTime { get; set; }

        [Column(TypeName = "tinyint")]
        public int LeaveCount { get; set; }

        public VacationsType_LeaveType VacationsType_LeaveType { get; set; }
        public int VacationsType_LeaveTypeId { get; set; }
        public ManualAttendanceEachDay ManualAttendenceEachDay { get; set; }
        public int ManualAttendenceEachDayId { get; set; }
    }
}
