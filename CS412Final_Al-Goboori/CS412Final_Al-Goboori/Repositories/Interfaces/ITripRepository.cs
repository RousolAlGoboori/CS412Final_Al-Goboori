using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories.Interfaces
{
    public interface ITripRepository
    {
        List<BookingTrips> GetBookingTrips(List<long> bookingIds);

        Trip CreateTrip(Trip trip);

        List<Trip> GetTrips();
        void AssociateBookingToTrips(long bookingId, List<long> tripIds);
        bool DeleteBookingTrip(long bookingId);


    }
}