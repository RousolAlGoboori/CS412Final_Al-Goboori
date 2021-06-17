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
        private readonly List<Trip> _trips = new List<Trip>() {
            new Trip() {
                Id = 1,
                Name = "Round trip",
                From = "Chicago",
                To = "Turkish"
            },
            new Trip() {
                Id = 2,
                Name = "One way",
                From = "Chicago",
                To = "Texas"
            },
            new Trip() {
                 Id = 3,
                Name = "Multi-city",
                From = "Chicago",
                To = "New York"
            }
        };

        private readonly List<Booking> _book = new List<Booking>() {
            new Booking() {
                Id = 1,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori"
                },
                DepartDate = DateTime.Now.AddDays(-1),
                ReturnDate = DateTime.Now.AddDays(10),

                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 1,
                         Name = "Multi-city",
                         From = "Chicago",
                         To = "New York"
                    },
                   
                }
            },
            new Booking() {
                Id = 2,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori"
                },
                DepartDate = DateTime.Now.AddDays(-15),
                ReturnDate = DateTime.Now.AddDays(13),
                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 1,
                         Name = "One way",
                         From = "Chicago",
                         To = "Turkish"
                    }
                }
            },
            new Booking() {
                Id = 3,
                Customer = new User() {
                    Id = 1,
                    First = "Rousol",
                    Last = "Al Goboori"
                },
                DepartDate = DateTime.Now.AddDays( 1),
                ReturnDate = DateTime.Now.AddDays(18),
                Trips = new List<Trip>() {
                    new Trip() {
                         Id = 2,
                         Name = "Round trip",
                         From = "Chicago",
                         To = "Texas"
                    }
                }
            }
        };


        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["trips"] = _book;
            BindGridView();

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

                 HiddenField id = (HiddenField)e.Row.FindControl("id");
                 id.Value = booking.Id.ToString();
            }


        }




    }






}