using CS412Final_Al_Goboori.BLL;
using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace CS412Final_Al_Goboori.Controllers
{
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingBLL _bookingBLL;

        public BookingController()
        {
            _bookingBLL = new BookingBLL();
        }

        [HttpGet]
        public List<Booking> GetBookings()
        {
            return _bookingBLL.GetBooking();
        }  

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetBookings(long id)
        {
           Booking booking = _bookingBLL.GetBookings(id);
            if (booking == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "An flight doesn't exist for that booking id");
            }

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }

        [HttpGet]
        [Route("customers/names/{partialName}")]
        public HttpResponseMessage GetCustomerNames(string partialName)
        {
            List<string> customerNames = new List<string>();
            List<Booking> bookings = _bookingBLL.GetBookingByCustomerName(partialName);
            if (bookings != null)
                customerNames = bookings.Select(x => x.CustomerName).Distinct().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, customerNames);
        }

        [HttpGet]
        [Route("customers/{partialName}")]
        public HttpResponseMessage GetOrdersByCustomerName(string partialName)
        {
            List<Booking> bookings = _bookingBLL.GetBookingByCustomerName(partialName);
            return Request.CreateResponse(HttpStatusCode.OK, bookings);
        }

        [HttpPost]
        [Route("addbooking")]
        public HttpResponseMessage CreateBooking(BookingRequest bookingRequest)
        {
            if (bookingRequest.Booking == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please provide a booking information");

            if (bookingRequest.TripIds == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please provide a Trip list");

            Booking booking = _bookingBLL.CreateBooking(bookingRequest.Booking, bookingRequest.TripIds);

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }

        [HttpPost]
        public HttpResponseMessage CreateBooking1(BookingRequest bookingRequest)
        {
            if (bookingRequest.Booking == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please provide a booking information");

            if (bookingRequest.TripIds == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please provide a Trip list");

            Booking booking = _bookingBLL.CreateBooking(bookingRequest.Booking, bookingRequest.TripIds);

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }

        [HttpPut]
        public HttpResponseMessage ModifyOrder(BookingRequest bookingRequest)
        {
            if (bookingRequest.Booking == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please provide a booking information");

            Booking booking = _bookingBLL.ModifyBooking(bookingRequest.Booking, bookingRequest.TripIds);

            if (booking == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "There was an issue modifying your booking");

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteBooking(long id)
        {
            Request.Headers.TryGetValues("APIKey", out var apiKey);
            if (apiKey == null || apiKey.FirstOrDefault() != "aya")
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Please provide the correct api key");

            Booking booking = _bookingBLL.GetBookings(id);
            if (booking == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "The booking id provided does not exist");

            bool bookingDeleted = _bookingBLL.DeleteBooking(id);
            if (bookingDeleted == false)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "There was an issue deleting your booking");

            return Request.CreateResponse(HttpStatusCode.OK, booking);
        }
    }
}
