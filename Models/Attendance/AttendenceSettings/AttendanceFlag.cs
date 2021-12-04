using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class AttendanceFlag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(7, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Color { get; set; }

        public string Description { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        public string Conditions { get; set; }
        public string Formula { get; set; }
    }
}
