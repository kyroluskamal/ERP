using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class DaysOff_HolidayLists
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [MaxLength(30, ErrorMessage = "MaxLengthExceeded_ERROR")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required_field")]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public HolidayLists HolidayLists { get; set; }
        public int HolidayListsId { get; set; }
    }
}
