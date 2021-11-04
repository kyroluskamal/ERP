using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance
{
    public class AttendancePermission
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int PermissionType { get; set; }
        
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ApplicationDate { get; set; }
        
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public bool HasNotes { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
