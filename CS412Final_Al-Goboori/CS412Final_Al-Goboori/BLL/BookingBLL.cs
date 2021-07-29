using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CS412Final_Al_Goboori.BLL
{
    public class BookingBLL : IBookingBLL
    {
        public readonly IBookingRepository _bookingRepository;
        public readonly ITripRepository _tripRepository;
        public readonly IUserRepository _userRepository;
        public BookingBLL()
        {
           _bookingRepository = new BookingRepository();
            _tripRepository = new TripRepository();
            _userRepository = new UserRepository();
        }
        public List<Booking> GetBooking(long userId = -1)
        {
            List<Booking> orders = AssociateTripsWithBooking(_bookingRepository.GetBooking(userId));
            AssociateUsersWithBooking(orders);
            return orders;
            /*List<Booking> bookings = _bookingRepository.GetBooking();

            List<BookingTrips> bookingTrips = _tripRepository.GetBookingTrips(bookings.Select(x => x.Id).ToList());

            foreach (BookingTrips os in bookingTrips)
            {
                Booking o = bookings.FirstOrDefault(x => x.Id == os.BookingId);
                if (o.Trips == null)
                    o.Trips = new List<Trip>();

                bookings.FirstOrDefault(x => x.Id == os.BookingId).Trips.Add(os.Trip);
            }
                return bookings;*/
        }
       
        public long GetBookingCount()
        {
            return _bookingRepository.GetBookingCount();
        }

        public List<Booking> GetCompletedBooking()
        {
            List<Booking> bookings = AssociateTripsWithBooking(_bookingRepository.GetCompletedBooking());
            AssociateUsersWithBooking(bookings);
            return bookings;
        }

        public decimal GetMoneyCollected()
        {
            decimal moneyCollected = 0;
             foreach (Booking book in _bookingRepository.GetBooking())
                 if (book.DepartDate < DateTime.Now)
                    moneyCollected += book.Total;
          
            return moneyCollected;
        }
        public bool DeleteBooking(long bookingId)
        {
            
            bool bookingTripsDeleted = _tripRepository.DeleteBookingTrip(bookingId);

            bool bookingDeleted = _bookingRepository.DeleteBooking(bookingId);

            return bookingTripsDeleted && bookingDeleted;
        }


        private List<Booking> AssociateTripsWithBooking(List<Booking> bookings)
        {
            List<BookingTrips> bookingTrips = _tripRepository.GetBookingTrips(bookings.Select(x => x.Id).ToList());

            foreach (BookingTrips os in bookingTrips)
            {
                Booking o = bookings.FirstOrDefault(x => x.Id == os.BookingId);
                if (o.Trips == null)
                    o.Trips = new List<Trip>();

                bookings.FirstOrDefault(x => x.Id == os.BookingId).Trips.Add(os.Trip);
            }
            return bookings;
        }
          private void AssociateUsersWithBooking(List<Booking> bookings)
          {

              List<User> users = _userRepository.GetUsers(bookings.Select(x => x.UserById).ToList());

              foreach (Booking o in bookings)
              {
                  User u = users.FirstOrDefault(x => x.Id == o.UserById);
                  if (u != null)
                  {
                      o.UserId = u;
                  }
              }
          }

       public Booking CreateBooking(Booking booking, List<long> tripIds)
        {
            
            booking = _bookingRepository.CreateBooking(booking);

           
            _tripRepository.AssociateBookingToTrips(booking.Id, tripIds);

             booking = AssociateTripsWithBooking(new List<Booking> { booking }).FirstOrDefault();
             AssociateUsersWithBooking(new List<Booking>() { booking });

            return booking;
        }

        public Booking GetBookings(long bookingId)
        {
            Booking booking = _bookingRepository.GetBookings(bookingId);
            if (booking != null)
            {
                booking = AssociateTripsWithBooking(new List<Booking> { booking }).FirstOrDefault();
                AssociateUsersWithBooking(new List<Booking> { booking });
            }

            return booking;
        }

        public Booking ModifyBooking(Booking booking, List<long> tripIds)
        {
            try
            {
                if (tripIds?.Count > 0)
                {
                }

                return booking;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Booking> GetBookingByCustomerName(string partialName)
        {
            List<Booking> bookings = AssociateTripsWithBooking(_bookingRepository.GetBookingByCustomerName(partialName));
            AssociateUsersWithBooking(bookings);
            return bookings;
        }
    }
}