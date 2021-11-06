using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Bookings
{
    public class Booking
    {
        public int Id { get; set; }
        [Column(TypeName = "Time")]
        [Required]
        public TimeSpan StartTime { get; set; }
        [Column(TypeName = "Time")]
        [Required]
        public TimeSpan EndTime { get; set; }
    }
}
