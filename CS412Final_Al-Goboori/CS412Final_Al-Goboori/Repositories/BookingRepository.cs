using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.DAL;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Booking CreateBooking(Booking booking)
        {
           return BookingDAL.CreateBooking( booking);
        }

        public bool DeleteBooking(long orderId)
        {
            return BookingDAL.DeleteBooking(orderId);
        }

        public List<Booking> GetBooking()
        {
            return BookingDAL.GetBooking();
        }

        public long GetBookingCount()
        {
            return BookingDAL.GetBookingCount();
        }

        public List<Booking> GetCompletedBooking()
        {
            return BookingDAL.GetCompletedBooking();
        }
    }
}