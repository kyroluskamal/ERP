using ERP.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Bookings
{
    public class Booking_Services
    {
        public int Id { get; set; }
        public Services Services { get; set; }
        public int ServicesId { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
