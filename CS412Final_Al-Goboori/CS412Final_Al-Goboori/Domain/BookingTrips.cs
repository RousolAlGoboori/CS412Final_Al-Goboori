using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Domain
{
    public class BookingTrips
    {
    
        public long BookingId { get; set; }
        public Trip Trip { get; set; }
    }
}