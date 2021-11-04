using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance
{
    public class AttendancePermission_DelayPermissions
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write the late times in minutes")]
        [Column(TypeName = "tinyint")]
        public int LateTime { get; set; }

        public AttendancePermission AttendancePermission { get; set; }
        public int AttendancePermissionId { get; set; }
    }
}
