using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Employee.Shifts
{
    public class ShiftsTimeDetails
    {
        public int Id { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan OnDutyTime { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan OffDutyTime { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan BeginningIn { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan EndingIn { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan BeginningOut { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan EndingOut { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "tinyint")]
        public int LateTime { get; set; }
        [Required]
        public string DaysOfWeeks { get; set; }

        [ForeignKey(nameof(ShiftId))]
        public EmployeeShifts EmployeeShifts { get; set; }
        public int ShiftId { get; set; }
    }
}
