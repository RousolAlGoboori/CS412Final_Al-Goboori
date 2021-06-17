using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Al_Goboori
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            Panel1.Visible = false;

            if (string.IsNullOrWhiteSpace(first.Text))
            {
                errors.Add("Please provide a first name.");
            }

            if (string.IsNullOrWhiteSpace(last.Text))
            {
                errors.Add("Please provide a last name.");
            }

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                errors.Add("Please provide a properly formatted email address.");
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errors.Add("Please provide a password.");
            }

            if (vpass.Text != txtPassword.Text)
            {
                errors.Add("password confirmation does not match password.");
            }

            if (errors.Count > 0)
            {
                Panel1.Visible = true;
                mErrors.Text = string.Join("<br />", errors);
                return;
            }
            User user = new User() {
                First = first.Text,
                Last = last.Text,
                Email = email.Text,
                Password = txtPassword.Text
            };
            Response.Redirect("MyTrips.aspx");
        }

        
    }
}