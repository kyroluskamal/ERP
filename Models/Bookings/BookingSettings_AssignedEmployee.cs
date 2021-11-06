using ERP.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Models.Bookings
{
    public class BookingSettings_AssignedEmployee
    {
        public int Id { get; set; }
        public Employees Employees { get; set; }
        public int EmployeesId { get; set; }
        public Booking_settings Booking_settings { get; set; }
        public int Booking_settingsId { get; set; }
    }
}
