using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Domain {

    [Serializable]
    public class Booking
    {
        public long Id { get; set; }
        public User Customer { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Passenger { get; set; }

        public List<Trip> Trips { get; set; }
    }
}