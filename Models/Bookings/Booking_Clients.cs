using ERP.Models.COCs;

namespace ERP.Models.Bookings
{
    public class Booking_Clients
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }

        public COC COC { get; set; }
        public int COCId { get; set; }
    }
}
