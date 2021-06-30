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
    public partial class ContactUs : System.Web.UI.Page
    {
        private readonly IUserBLL _userBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void countactus_Click(object sender, EventArgs e)
        {

            List<string> errors = new List<string>();
            Panel1.Visible = false;

            if (string.IsNullOrWhiteSpace(name.Text))
            {
                errors.Add("Enter your Name");
            }

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                errors.Add("Enter your email");
            }

            if (string.IsNullOrWhiteSpace(comment.Text))
            {
                errors.Add("Enter your comment");
            }
            if (errors.Count == 0)
            {
                User user = _userBLL.Get(name.Text,email.Text.Trim());

                if (user != null)
                {
                    Session["user"] = user;
                    Response.Redirect("MyTrips.aspx");
                }
                else
                {
                    errors.Add("Invalid username or email.");
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