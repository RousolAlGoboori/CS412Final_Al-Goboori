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

        public List<Booking> GetBooking(long userId = -1)
        {
            return BookingDAL.GetBooking(userId);
        }

        public List<Booking> GetBookingByCustomerName(string partialName)
        {
            return BookingDAL.GetBookingByCustomerName(partialName);
        }

        public long GetBookingCount()
        {
            return BookingDAL.GetBookingCount();
        }

        public Booking GetBookings(long bookingId)
        {
            return BookingDAL.GetBookings(bookingId);
        }

        public List<Booking> GetCompletedBooking()
        {
            return BookingDAL.GetCompletedBooking();
        }
    }
}