using ERP.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance
{
    public class AttendanceSheet
    {
        public int Id { get; set; }
        [Column(TypeName = "smallint")]
        public int TotalWorkingDays { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_Present_Days { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_Delays_Days { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_MinDelays { get; set; }
        [Column(TypeName = "smallint")]
        public int Expected_WorkingHours { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_Absence_Days { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_SignIn_Only { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_SignOut_Only { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_EarlyLeave_Days { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_EarlyLeave_Min { get; set; }
        [Column(TypeName = "smallint")]
        public int Actual_WorkingHours { get; set; }
        [Column(TypeName = "smallint")]
        public int Total_Vacations { get; set; }

        [Column(TypeName = "bit")]
        public bool IsApproved { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FiscalYearStartDate { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
    }
}
