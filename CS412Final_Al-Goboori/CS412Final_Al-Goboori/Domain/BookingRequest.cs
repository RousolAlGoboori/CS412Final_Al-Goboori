using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Domain
{
    public class BookingRequest
    {
        public Booking Booking { get; set; }
        public List<long> TripIds { get; set; }
    }
}