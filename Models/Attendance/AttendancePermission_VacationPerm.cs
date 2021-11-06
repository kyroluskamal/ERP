using ERP.Models.Attendance.AttendenceSettings;

namespace ERP.Models.Attendance
{
    public class AttendancePermission_VacationPerm
    {
        public int Id { get; set; }
        public VacationsType_LeaveType VacationsType_LeaveType { get; set; }
        public int VacationsType_LeaveTypeId { get; set; }
        public AttendancePermission AttendancePermission { get; set; }
        public int AttendancePermissionId { get; set; }
    }
}
