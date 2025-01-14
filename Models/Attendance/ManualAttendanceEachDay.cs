﻿using ERP.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance
{
    public class ManualAttendanceEachDay
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime AttendanceDate { get; set; }

        [Column(TypeName = "bit")]
        public bool HasNotes { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
