using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Al_Goboori
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool loggedIn = true;
            if (loggedIn == false)
                Response.Redirect("Login.aspx");

        }
    }
}