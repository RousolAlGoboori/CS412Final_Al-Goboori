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
        List<Booking> GetBooking();
        long GetBookingCount();
        List<Booking> GetCompletedBooking();
        Booking CreateBooking(Booking booking, List<long> tripIds);
        bool DeleteBooking(long orderId);

    }
}