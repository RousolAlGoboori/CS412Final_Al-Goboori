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
        private readonly INotificationBLL _notificationBLL = new NotificationBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void countactus_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(name.Text) ||
               string.IsNullOrWhiteSpace(email.Text) ||
               string.IsNullOrWhiteSpace(comment.Text))
            {
                ePanel1.Visible = true;
                mErrors.Text = "Please ensure that all fields are filled.";
                return;
            }
            SendFeedback(name.Text, email.Text, comment.Text);
        }
        public void SendFeedback(string userName, string userEmail, string comment)
        {
            string to = "rousolalgoboori@gmail.com";
            string subject = "Tell us about your feedback";
            string replyTo = to;
            string body = $@"
                            <p>User Email: {userEmail}</p>
                            <p>User Name: {userName}</p>
                            <p>User Comment:<br>
                            {comment}
                            </p>
                            ";

            _notificationBLL.SendEmail(to, subject, body, replyTo);
        }
    }

}