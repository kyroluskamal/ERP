using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Bookings
{
    public class Booking_Clients
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }

        public ERP.Models.COC.COC COC { get; set; }
        public int COCId { get; set; }
    }
}
