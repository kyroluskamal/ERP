using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Attendance
{
    public class ManualAttendanceEachDay_notes
    {
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }
        public ManualAttendanceEachDay ManualAttendenceEachDay { get; set; }
        public int ManualAttendenceEachDayId { get; set; }
    }
}
