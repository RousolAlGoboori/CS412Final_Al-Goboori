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
                    //grab the service only if it's selected in the checkbox list
                    tripIds.Add(long.Parse(trip.Value));
                }
            }

            //do validation here before we create our order to make sure everything is good
            CreateBooking(from.Text, to.Text, DateTime.Parse(depart.Text), DateTime.Parse(returnDate.Text), tripIds);


          /*  List<string> errors = new List<string>();
            if (RadioButton1.Checked)
                errors.Add("Round trip ");

            if (RadioButton2.Checked)
                errors.Add( "One way");


            if (RadioButton3.Checked)
                errors.Add("Multi-city");

            Panel1.Visible = false;

            if (string.IsNullOrWhiteSpace(from.Text))
            {
                errors.Add("Enter your departure city.");
            }

            if (string.IsNullOrWhiteSpace(to.Text))
            {
                errors.Add("Enter your  city.");
            }

            if (errors.Count == 0)
            {
                bool matchedInDatabase = false;
                if (from.Text.ToLower() == "Chicago" && to.Text.ToLower() == "New York")
                {
                    matchedInDatabase = true;
                }

                if (matchedInDatabase)
                {
                    Booking book = new Booking()

                    {
                        DepartDate = DateTime.Now.AddDays(1),
                        ReturnDate = DateTime.Now.AddDays(60),
                       // Passenger = 1,
                    };
                }
                else
                {
                    errors.Add("Invalid information.");
                }
            }
            if (errors.Count > 0)
            {
                Panel1.Visible = true;
                mErrors.Text = string.Join("<br />", errors);
                return;

            }*/
        }

        protected void createTrip_Click(object sender, EventArgs e)
        {
            decimal price = 0;

            //try to convert the price to a decimal and if successful, lets create the service
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