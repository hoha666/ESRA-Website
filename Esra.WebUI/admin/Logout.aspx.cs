using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esra.WebUI.admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("IsUserLogedIn");
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}