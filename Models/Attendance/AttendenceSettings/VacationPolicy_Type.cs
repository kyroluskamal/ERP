using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class VacationPolicy_Type
    {
        public int Id { get; set; }
        public VacationsPolicy_LeavePolicy VacationsPolicy_LeavePolicy{ get; set; }
        public int VacationsPolicy_LeavePolicyId{ get; set; }

        public VacationsType_LeaveType VacationsType_LeaveType { get; set; }
        public int VacationsType_LeaveTypeId { get; set; }
    }
}
