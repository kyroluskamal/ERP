using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class VacationsPolicy_LeavePolicy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, write a name")]
        public string Name { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
