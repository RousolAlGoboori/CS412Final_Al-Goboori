using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Al_Goboori.UserControls
{
    public partial class BookingControl : System.Web.UI.UserControl
    {
        public Booking Booking
        {
            get
            {
                return (Booking)ViewState["booking"];
            }
            set
            {
                ViewState["booking"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Booking != null)
            {
                litBookingNumber.Text = Booking.Id.ToString();
                litCustomerName.Text = Booking.CustomerName;
                litDepartDate.Text = Booking.DepartDate.ToString();
                litReturnDate.Text = Booking.ReturnDate.ToString();
                litFrom.Text = Booking.From;
                litTo.Text = Booking.To;
                lblTotal.Text = Booking.Total.ToString("c");
                BindTripRepeater();
            }

        }
        public void BindTripRepeater()
        {
            TripRepeater.DataSource = Booking.Trips;
            TripRepeater.DataBind();
        }

        protected void TripRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               Trip trip = (Trip)e.Item.DataItem;

                Label TripName = (Label)e.Item.FindControl("TripName");
                Label TripPrice = (Label)e.Item.FindControl("TripPrice");

                TripName.Text = trip.Name;
                TripPrice.Text = trip.Price.ToString("c");
            }

        }
    }
}