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
    public partial class MyTripsPage : System.Web.UI.Page
    {
        private readonly IBookingBLL _bookingBLL = new BookingBLL();
        private readonly List<Trip> _trips = new List<Trip>() {
            new Trip() {
                Id = 1,
                Name = "Round trip",
                From = "Chicago",
                To = "Turkish",
                 Price = 1000
            },
            new Trip() {
                Id = 2,
                Name = "One way",
                From = "Chicago",
                To = "Texas",
                 Price = 500
            },
            new Trip() {
                 Id = 3,
                Name = "Multi-city",
                From = "Chicago",
                To = "New York",
                 Price = 1500
            }
        };

       


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ViewState["trips"] = _bookingBLL.GetBooking();

                BindGridView();
                SetPageData();
                litGiftMiles.Text = GetGiftMiles().ToString();
            }

        }
    
        private void BindGridView()

        {
            userTrips.DataSource = ViewState["trips"];
            userTrips.DataBind();
        }
      

        protected void userTrips_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Booking booking = (Booking)e.Row.DataItem;

                        Label customerName = (Label)e.Row.FindControl("userName");
                        customerName.Text = $"{booking.Customer.First} {booking.Customer.Last}";

                        Label services = (Label)e.Row.FindControl("flightType");
                        services.Text = string.Join(", ", booking.Trips.Select(x => x.Name));

                        Label servic = (Label)e.Row.FindControl("from");
                        servic.Text = string.Join(", ", booking.Trips.Select(x => x.From));

                        Label servi = (Label)e.Row.FindControl("to");
                        servi.Text = string.Join(", ", booking.Trips.Select(x => x.To));

                        Label serviceDate1 = (Label)e.Row.FindControl("dDate");
                        serviceDate1.Text = booking.DepartDate.ToShortDateString();

                        Label serviceDate2 = (Label)e.Row.FindControl("rDate");
                        serviceDate2.Text = booking.ReturnDate.ToShortDateString();

                        Label bPrice = (Label)e.Row.FindControl("lblOrderPrice");
                        bPrice.Text = $"${booking.Total}";


                HiddenField id = (HiddenField)e.Row.FindControl("id");
                        id.Value = booking.Id.ToString();
                    }

        }
        private void SetPageData()
        {
            User user = (User)Session["user"];
           
            litMoneyCollected.Text = _bookingBLL.GetMoneyCollected().ToString();
            litCount.Text = GetCount().ToString();
        }
        private int GetGiftMiles()
        {
            int ordersCompleted = 0;
            foreach (Booking book in ((List<Booking>)ViewState["trips"]))
                if (book.DepartDate < DateTime.Now)
                    ordersCompleted++;

            return ordersCompleted * 1000;
            
        }
        private int GetCount()
        {
            return ((List<Booking>)ViewState["trips"]).Count();
        }




        protected void userTrips_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = userTrips.Rows[e.RowIndex];

            HiddenField id = (HiddenField)row.FindControl("id");
            long Id = 0;
            if (long.TryParse(id.Value, out Id))
            {
                Booking book = ((List<Booking>)ViewState["trips"]).FirstOrDefault(x => x.Id == Id);
                if (book != null)
                {
                    ((List<Booking>)ViewState["trips"]).Remove(book);
                    
                    BindGridView();
                    SetPageData();
                   
                }
            }
        }
    }






}