using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Data;

namespace Esra.WebUI
{
    public partial class first : System.Web.UI.MasterPage
    {
        public string firstPart = "IMG/Banners/";
        public string secondpart = ".jpg";
        public string notifme = "";
        public string myLink = "";
        public string fileURL = "";
        public string totalVisit = "";
        public string dailyVisit = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache); //Cache-Control : no-cache, Pragma : no-cache
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1)); //Expires : date time
            Response.Cache.SetNoStore(); //Cache-Control :  no-store
            Response.Cache.SetProxyMaxAge(new TimeSpan(0, 0, 0)); //Cache-Control: s-maxage=0
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);//Cache-Control:  must-revalidate

            // amar bazdid website visits
            string connectionString = ConfigurationManager.AppSettings["esra_sadatiConnectionString1"].ToString();
            SqlConnection sqConn = new SqlConnection(connectionString);
            //checking for duplicates
            string queryString = "select * from website_visits where info = N'" + Context.Session.SessionID.ToString() + "' order by id desc";
            if (!Request.Browser.Crawler)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand comm4 = new SqlCommand(queryString, connection);
                    SqlDataAdapter sda = new SqlDataAdapter(comm4);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DateTime old = (DateTime)dt.Rows[0]["time"];
                        DateTime now = DateTime.Now;
                        TimeSpan diff = now - old;
                        if (diff.TotalMinutes > 30)
                        {
                            string ipaddress;
                            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (ipaddress == "" || ipaddress == null)
                                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
                            string myQuery = "insert into website_visits (ip,info,time) values ('" + ipaddress + "','" + Context.Session.SessionID.ToString() + "', '" + DateTime.Now.ToString() + "')";
                            SqlCommand sComm = new SqlCommand(myQuery, sqConn);
                            using (sComm)
                            {
                                sqConn.Open();
                                sComm.ExecuteNonQuery();
                                sqConn.Close();
                            }
                        }
                    }
                    else
                    {
                        string ipaddress;
                        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (ipaddress == "" || ipaddress == null)
                            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
                        string myQuery = "insert into website_visits (ip,info,time) values ('" + ipaddress + "','" + Context.Session.SessionID.ToString() + "', '" + DateTime.Now.ToString() + "')";
                        SqlCommand sComm = new SqlCommand(myQuery, sqConn);
                        using (sComm)
                        {
                            sqConn.Open();
                            sComm.ExecuteNonQuery();
                            sqConn.Close();
                        }
                    }
                }
            }

            // updating visit information for showing
            string queryString2 = "select count (*) from website_visits";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comm4 = new SqlCommand(queryString2, connection);
                SqlDataAdapter sda = new SqlDataAdapter(comm4);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalVisit = dt.Rows[0][0].ToString();
                }
                else
                {
                    totalVisit = "0";
                }
            }
            string queryString3 = "select count (*) from website_visits where cast(time as Date) = cast(getdate() as Date)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comm4 = new SqlCommand(queryString3, connection);
                SqlDataAdapter sda = new SqlDataAdapter(comm4);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dailyVisit = dt.Rows[0][0].ToString();
                }
                else
                {
                    dailyVisit = "0";
                }
            }



            string reshteh = "";
            //notifme = this.Page.Request.Url.ToString();
            notifme = this.Page.Request.FilePath;
            for (int i = notifme.Length - 1; i >= 0 && notifme[i] != '/'; i--)
            {
                if (i > 0)
                    if (notifme[i].ToString() == "?")
                        reshteh = "_" + reshteh;
                    else
                        reshteh = notifme[i] + reshteh;
            }
            notifme = reshteh;
            if (notifme.Contains("CMSPage"))
            {
                reshteh = "";
                notifme = this.Page.Request.Url.ToString();
                //notifme = this.Page.Request.FilePath;
                for (int i = notifme.Length - 1; i >= 0 && notifme[i] != '/'; i--)
                {
                    if (i > 0)
                        if (notifme[i].ToString() == "?")
                            reshteh = "_" + reshteh;
                        else
                            reshteh = notifme[i] + reshteh;
                }
                notifme = reshteh;
                fileURL = firstPart + notifme + secondpart;
                myLink = "< img class='width100 imgbk1' src='../" + fileURL + "'>";
                if (!File.Exists(Server.MapPath(fileURL)))
                {
                    fileURL = "IMG/back1.jpg";
                }
            }
            else
            {
                ////////////////////////////////////////
                if (Request.QueryString["pf"] != null && Request.QueryString["pf"].ToString().Equals("8"))
                {
                    //mobile
                    fileURL = "IMG/Banners/mobileBanner.jpg";
                    //myLink = "< img class='width100 imgbk1' src='/IMG/back2.jpg'>";
                }
                else
                {
                    //other
                    fileURL = firstPart + notifme + secondpart;
                    myLink = "< img class='width100 imgbk1' src='../" + fileURL + "'>";
                    if (!File.Exists(Server.MapPath(fileURL)))
                    {
                        fileURL = "IMG/back1.jpg";
                    }
                }

            }


        }
    }
}