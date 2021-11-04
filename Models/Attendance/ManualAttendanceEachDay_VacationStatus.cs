﻿using ERP.Models.Attendance.AttendenceSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance
{
    public class ManualAttendanceEachDay_VacationStatus
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int VacationCount { get; set; }

        public VacationsType_LeaveType VacationsType_LeaveType { get; set; }
        public int VacationsType_LeaveTypeId { get; set; }
        public ManualAttendanceEachDay ManualAttendenceEachDay { get; set; }
        public int ManualAttendenceEachDayId { get; set; }
    }
}