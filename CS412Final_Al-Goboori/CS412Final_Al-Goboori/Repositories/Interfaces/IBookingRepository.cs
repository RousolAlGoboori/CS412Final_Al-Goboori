using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetBooking(long userId = -1);
        Booking GetBookings(long bookingId);
        Booking CreateBooking(Booking booking);
        long GetBookingCount();
        List<Booking> GetCompletedBooking();
        bool DeleteBooking(long bookingId);
      
        List<Booking> GetBookingByCustomerName(string partialName);
    }
}