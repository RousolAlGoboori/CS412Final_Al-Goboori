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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
                mErrors.Text = "Round trip ";

            if (RadioButton2.Checked)
                mErrors.Text = "One way";

            if (RadioButton3.Checked)
                mErrors.Text = "Multi-city";
        }

        protected void search_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            Panel1.Visible = false;

            if (string.IsNullOrWhiteSpace(from.Text))
            {
                errors.Add("Enter your city.");
            }

            if (string.IsNullOrWhiteSpace(to.Text))
            {
                errors.Add("Enter your city.");
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
                        Passenger = 1,
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

            }
        }
    }
}