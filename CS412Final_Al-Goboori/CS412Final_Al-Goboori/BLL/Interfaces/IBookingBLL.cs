using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL.Interfaces
{
    public interface IBookingBLL
    {
        decimal GetMoneyCollected();
        List<Booking> GetBooking(long userId = -1);
        long GetBookingCount();
        Booking GetBookings(long bookingId);
        List<Booking> GetCompletedBooking();
        Booking CreateBooking(Booking booking, List<long> tripIds);
        bool DeleteBooking(long bookingId);
      
        Booking ModifyBooking(Booking booking, List<long> tripIds);
        List<Booking> GetBookingByCustomerName(string partialName);

    }
}