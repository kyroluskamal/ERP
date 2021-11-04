using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Attendance.AttendenceSettings
{
    public class DaysOff_HolidayLists
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public HolidayLists HolidayLists { get; set; }
        public int HolidayListsId { get; set; }
    }
}
