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
    public partial class LoginPage : System.Web.UI.Page
    {
        private readonly IUserBLL _userBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            Panel1.Visible = false;

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                errors.Add("Please provide an email.");
            }

            if (string.IsNullOrWhiteSpace(pass.Text))
            {
                errors.Add("Please provide a password.");
            }


            if (errors.Count == 0)
            {
                User user = _userBLL.GetUser(email.Text.Trim(), pass.Text);

                if (user != null)
                {
                    Session["user"] = user;
                    Response.Redirect("MyTrips.aspx");
                }
                else
                {
                    errors.Add("Invalid username or password.");
                }
            }
            if (errors.Count > 0)
            {
                Panel1.Visible = true;
                Label.Text = string.Join("<br />", errors);
                return;
            }

        }
    }
}