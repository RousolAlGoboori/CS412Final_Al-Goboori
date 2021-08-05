using CS412Final_Al_Goboori.BLL;
using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.UserControls;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ViewState["trips"] = _bookingBLL.GetBooking();
                BindAllGrids();
                //BindGridView();
                // SetPageData();
                int giftMiles = _bookingBLL.GetCompletedBooking().Count() * 1000;
                litGiftMiles.Text = giftMiles.ToString();
               
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

                customerName.Text = booking.CustomerName;

                Label services = (Label)e.Row.FindControl("flightType");
                services.Text = string.Join(", ", booking.Trips.Select(x => x.Name));

                Label servic = (Label)e.Row.FindControl("from");

                servic.Text = booking.From;


                Label servi = (Label)e.Row.FindControl("to");

                servi.Text = booking.To;

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

            
            litCount.Text = _bookingBLL.GetBookingCount().ToString();

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
                    User user = (User)Session["user"];

                    _bookingBLL.DeleteBooking(book.Id);

                    ViewState["trips"] = _bookingBLL.GetBooking();

                    //BindGridView();
                    //SetPageData();
                    BindAllGrids();

                }
            }
        }
        private void BindAllGrids()
        {
            BindGridView();
            SetPageData();
            BindBookingControlRepeater();
        }
        private void BindBookingControlRepeater()
        {
            BookingControlRepeater.DataSource = ViewState["trips"];
            BookingControlRepeater.DataBind();
        }

        

        protected void BookingControlRepeater_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Booking booking = (Booking)e.Item.DataItem;
                BookingControl bc = (BookingControl)e.Item.FindControl("BookingControl");
                bc.Booking = booking;
            }

        }
    }






}