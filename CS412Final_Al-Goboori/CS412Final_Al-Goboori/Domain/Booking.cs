using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Domain {

    [Serializable]
    public class Booking
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
      
        public DateTime DepartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string From { get; set; }
       public string To { get; set; }
        public User UserId { get; set; }
        public long UserById { get; set; }

        public List<Trip> Trips { get; set; }
        public decimal Total => Trips == null ? 0M : Trips.Sum(x => x.Price);
        public Booking()
        {
            Trips = new List<Trip>();
        }
    }
}