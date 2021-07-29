using CS412Final_Al_Goboori.BLL;
using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Al_Goboori
{
    public partial class BookAFlightPage : System.Web.UI.Page
    {
        private readonly IBookingBLL _bookingBLL = new BookingBLL();
        private readonly ITripBLL _tripBLL = new TripBLL();
        private readonly INotificationBLL _notificationBLL = new NotificationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                rebindTrips();
            }
        }

        private void rebindTrips()
        {
            

            bookingList.Items.Clear();
            foreach (Trip s in _tripBLL.GetTrips())
            {
                ListItem listItem = new ListItem($"{s.Name}", s.Id.ToString());
                bookingList.Items.Add(listItem);
            }
        }



        protected void createFlight_Click(object sender, EventArgs e)
        {
            List<long> tripIds = new List<long>();
            foreach (ListItem trip in bookingList.Items)
            {
                if (trip.Selected)
                {
                    tripIds.Add(long.Parse(trip.Value));
                }
            }
            Booking b = new Booking()
            {
                CustomerName = customerName.Text,
                From = from.Text,
                To = to.Text,
                DepartDate = DateTime.Parse(depart.Text),
                ReturnDate = DateTime.Parse(returnDate.Text),
                UserId = (User)Session["user"]
            };
            _bookingBLL.CreateBooking(b, tripIds);
            SendFeedback(customerName.Text, from.Text, to.Text, depart.Text, returnDate.Text);


        }
        public void SendFeedback(string customerName, string from, string lTo, string depart, string returnDate)
        {
            string to = "rousolalgoboori@gmail.com";
            string subject = "Booking a flight";
            string replyTo = to;
            string body = $@"
                            <p>Booking CustomerName: {customerName}</p>
                            <p>Booking From: {from}</p>
                            <p>Booking To: {lTo}</p>
                            <p>Booking DepartDate: {depart}</p>
                            <p>Booking  ReturnDate: {returnDate}</p>
                            ";

            _notificationBLL.SendEmail(to, subject, body, replyTo);
        }

        protected void createTrip_Click(object sender, EventArgs e)
        {
            decimal price = 0M;

            
            if (decimal.TryParse(tripPrice.Text, out price))
            {
               Trip trip = new Trip()
                {
                    Name = tripName.Text,
                    Price = price
                };
                trip = _tripBLL.CreateTrip(trip);
                if (trip.Id > 0)
                {
                    tripName.Text = "";
                    tripPrice.Text = "";
                    rebindTrips();
                }
            }
        }


       

    }
}