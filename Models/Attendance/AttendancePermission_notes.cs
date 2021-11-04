using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance
{
    public class AttendancePermission_notes
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public AttendancePermission AttendancePermission { get; set; }
        public int AttendancePermissionId { get; set; }
    }
}
