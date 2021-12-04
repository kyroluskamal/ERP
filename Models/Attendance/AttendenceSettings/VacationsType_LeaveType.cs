using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class VacationsType_LeaveType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(20)]
        public string Color { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "smallint")]
        public int MaxDaysAllowedPerYear { get; set; }
        [Column(TypeName = "tinyint")]
        public int MaximumContinuousDaysApplicable { get; set; }
        [Column(TypeName = "tinyint")]
        public int ApplicableAfter_HowManyDays { get; set; }
        [Column(TypeName = "bit")]
        public bool IsNeedPermission { get; set; }
    }
}
