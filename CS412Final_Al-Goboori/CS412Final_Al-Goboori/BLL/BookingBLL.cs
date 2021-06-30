using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL
{
    public class BookingBLL : IBookingBLL
    {
        public readonly IBookingRepository _bookingRepository;
        public BookingBLL()
        {
           _bookingRepository = new BookingRepository();
        }
        public List<Booking> GetBooking()
        {
            return _bookingRepository.GetBooking();
        }

        public decimal GetMoneyCollected()
        {
            decimal moneyCollected = 0;
            foreach (Booking book in _bookingRepository.GetBooking())
                if (book.DepartDate < DateTime.Now)
                    moneyCollected += book.Total;

            return moneyCollected;
        }


    }
}