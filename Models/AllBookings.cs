using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Models
{
    public class AllBookings
    {
        public IEnumerable<CheckIns> CheckedIn { get; set; }
        public IEnumerable<Bookings> Booked { get; set; }
        public int BookedKids { get; set; }
        public int BookedAdults { get; set; }
        public int CheckedInKids { get; set; }
        public int CheckedInAdults { get; set; }
        public int TotalCheckedIn { get; set; }
        public int TotalBooked { get; set; }
        public DateTime Date { get; set; }
    }
}
