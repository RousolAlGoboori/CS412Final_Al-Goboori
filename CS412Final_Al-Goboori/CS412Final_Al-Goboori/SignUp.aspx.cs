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
    public partial class SignUpPage : System.Web.UI.Page
    {
        private readonly INotificationBLL _notificationBLL = new NotificationBLL();
        private readonly IUserBLL _userBLL = new UserBLL();
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
            if (string.IsNullOrWhiteSpace(phone.Text))
            {
                errors.Add("Please provide phone number.");
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
                Phone = phone.Text,
                Password = txtPassword.Text
            };
            User newUser = _userBLL.CreateUser(user);
            if (newUser != null)
            {
                Session["user"] = newUser;
                Response.Redirect("MyTrips.aspx");
            }

            Panel1.Visible = true;
            mErrors.Text = "User was not created. Please try again.";
            SendFeedback(first.Text, last.Text, email.Text, phone.Text, txtPassword.Text);
        }
        public void SendFeedback(string first, string last, string userEmail, string phone, string password)
        {
            string to = userEmail;
            string subject = "Create your account";
            string replyTo = to;
            string body = $@"
                            <p>User First: {first}</p>
                            <p>User Last: {last}</p>
                            <p>User Email: {userEmail}</p>
                            <p>User Phone: {phone}</p>
                            <p>User Password: {password}</p>
                            ";

            _notificationBLL.SendEmail(to, subject, body, replyTo);
        }


    }
}