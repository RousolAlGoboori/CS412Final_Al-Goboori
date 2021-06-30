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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Trip> trips = GetServices();
            foreach (Trip s in trips)
            {
                ListItem listItem = new ListItem($"{s.Name} - {s.Price}", s.Id.ToString());
                bookingList.Items.Add(listItem);
            }

        }
        private List<Trip> GetServices()
        {
            return new List<Trip>();
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

            CreateBooking(from.Text, to.Text, DateTime.Parse(depart.Text), DateTime.Parse(returnDate.Text), tripIds);


         
        }

        protected void createTrip_Click(object sender, EventArgs e)
        {
            decimal price = 0;

            if (decimal.TryParse(tripPrice.Text, out price))
            {
                CreateTrip(tripName.Text, price);
            }

        }
        private bool CreateBooking(string from, string to, DateTime departDate, DateTime rDate, List<long> tripIds)
        {
            List<Trip> trips = new List<Trip>();
            foreach (long tripId in tripIds)
            {
                trips.Add(new Trip() { Id = tripId });
            }

            Booking b = new Booking()
            {
                From = from,
                To = to,
                DepartDate = departDate,
                ReturnDate = rDate,
                Trips = trips
            };

            
            return false;
        }

        private bool CreateTrip(string name, decimal price)
        {
           Trip trip = new Trip()
            {
                Name = name,
                Price = price
            };

            return false;
        }

    }
}