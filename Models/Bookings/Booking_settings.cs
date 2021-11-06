using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Bookings
{
    public class Booking_settings
    {
        public int Id { get; set; }
        [Required]
        public int BookingTimeDivider { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAssignedToStaff { get; set; }
        [Column(TypeName = "bit")]
        public bool IsOnlyOneService { get; set; }

        public int BookingPaymentSettings { get; set; }
    }
}
