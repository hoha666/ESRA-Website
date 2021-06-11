using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.COMMON;
using Esra.BUSINESS;

namespace Esra.WebUI.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_login_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_user_name.Text)) return;
            user userInfo = busUsers.GetUserInfo(txt_user_name.Text);
            if (userInfo == null) return;
            string userName = userInfo.username;
            string passWord = userInfo.password;
            var t = comCryption.EncryptString(txt_password.Text);
            
            if (userName == txt_user_name.Text && passWord == t)
            {
                Session["IsUserLogedIn"] = comCryption.EncryptString(true.ToString());
                Session.Timeout = 30;
                Response.Redirect("Default.aspx");

            }
            else
            {
                Session["IsUserLogedIn"] = comCryption.EncryptString(false.ToString());
                Response.Redirect("Login.aspx");

            }
        }
    }
}