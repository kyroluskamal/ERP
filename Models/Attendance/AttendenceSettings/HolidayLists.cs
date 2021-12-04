using System.ComponentModel.DataAnnotations;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class HolidayLists
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        public string Name { get; set; }
    }
}
