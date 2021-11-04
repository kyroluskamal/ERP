﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance
{
    public class AttendanceDaysPerEmp
    {
        public int Id { get; set; }

        public AttendanceSheet AttendanceSheet { get; set; }
        public int AttendanceSheetId { get; set; }
        public ManualAttendanceEachDay ManualAttendenceEachDay { get; set; }
        public int ManualAttendenceEachDayId { get; set; }
    }
}
