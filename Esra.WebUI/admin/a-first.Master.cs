using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.COMMON;

namespace Esra.WebUI.admin
{
    public partial class a_first : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsUserLogedIn"] != null)
            {
                if (Session["IsUserLogedIn"].ToString() != comCryption.EncryptString(true.ToString()))
                    Response.Redirect("Login.aspx");

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}