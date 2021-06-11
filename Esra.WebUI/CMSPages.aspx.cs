using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
namespace Esra.WebUI
{
    public partial class CMSPages : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            int id = 0;
            Int32.TryParse(Request.QueryString["id"], out id);
            var pages = busTbl_StaticPage.getPage(id);
            if (pages != null && pages.ID > 0)
            {
                switch (pages.MasterID)
                {
                    case 1:
                        this.MasterPageFile = "~/first.Master";
                        break;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)

        {
            string fop = Request.Url.ToString();
                fop = fop.Substring(fop.LastIndexOf("/") + 1);
                var pages = busTbl_StaticPage.getPage(fop);
                if (pages != null && pages.ID > 0)
                {
                    pageContent.InnerHtml = pages.Content;
                    HttpContext.Current.RewritePath("/CMSPages.aspx?id=" + pages.ID,false);
                }
        }
    }
}