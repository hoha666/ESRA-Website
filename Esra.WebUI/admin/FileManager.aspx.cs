using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;

namespace Esra.WebUI.admin
{
    public partial class FileManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGridView();
        }

        protected void btnAddFileIntroInfo_OnServerClick(object sender, EventArgs e)
        {

            string sessionId = HttpContext.Current.Session.SessionID + "\\";
            string fileFolder = HttpContext.Current.Server.MapPath("/./") + "files\\";
            foreach (string file in txtFileName.Text.Split(','))
            {
                if (!string.IsNullOrEmpty(file))
                {
                    string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + file;
                    try
                    {
                        File.Move(tempFolder, fileFolder + "\\" + file);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            Response.Redirect("FileManager.aspx");

        }
        private void BindGridView()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("/./") + "files\\");
            var filenames = dirInfo.GetFiles();

            var dataSource = filenames;
            if (dataSource.Any())
            {
                var customDataSource = from p in dataSource
                                       select new
                                       {
                                           id = p.Name,
                                           name = p.Name.Substring(0,p.Name.IndexOf("$$_")),
                                           size = p.Length / 1024 + " KB",
                                           date = p.CreationTime,
                                           ext = p.Extension.Replace(".", ""),
                                           link = $"<button onclick=\"window.prompt('با کنترل c کنترل v کپی کنید.','../files/{p.Name}');\" type=\"button\">کپی</button>"
                                       };

                gvFileList.DataSource = customDataSource;
                gvFileList.DataBind();
                gvFileList.UseAccessibleHeader = true;
                gvFileList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            else
            {
                gvFileList.Columns.Clear();

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dr = dt.NewRow();
                dr["Col1"] = "رکوردی برای نمایش وجود ندارد";

                dt.Rows.Add(dr);

                gvFileList.DataSource = dt;
                gvFileList.DataBind();
            }
        }

        protected void gvFileList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string fileFolder = HttpContext.Current.Server.MapPath("/./") + "files\\";
            
            string fileName = HttpUtility.HtmlDecode(gvFileList.Rows[e.RowIndex].Cells[0].Text);
            if (File.Exists(fileFolder + "\\" + fileName))
            {
                File.Delete(fileFolder + "\\" + fileName);
            }
            BindGridView();

        }
    }
}