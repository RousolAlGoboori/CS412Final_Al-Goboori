using CS412Final_Al_Goboori.DAL;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories
{
    public class TripRepository : ITripRepository
    {
        public void AssociateBookingToTrips(long bookingId, List<long> tripIds)
        {
             TripDAL.AssociateBookingToTrips(bookingId,tripIds);
        }

        public Trip CreateTrip(Trip trip)
        {
            return TripDAL.CreateTrip(trip);
        }

        public bool DeleteBookingTrip(long bookingId)
        {
            return TripDAL.DeleteBookingTrip(bookingId);
        }

        public List<BookingTrips> GetBookingTrips(List<long> bookingIds)
        {
            return TripDAL.GetBookingTrips(bookingIds);
        }

        public List<Trip> GetTrips()
        {
            return TripDAL.GetTrips();
        }
    }
}