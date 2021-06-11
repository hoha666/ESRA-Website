using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKEditor.NET;
using Esra.BUSINESS;
using Esra.COMMON;


namespace Esra.WebUI.admin
{
    public partial class GenerateStaticPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
                EditStaticPage.Visible = false;
                cancelEditing.Visible = false;


                #region StaticPage
                long rowCount = 0;

                var tempStaticPage = busTbl_StaticPage.getAllPage(out rowCount);
                slct_Root.DataTextField = "Title";
                slct_Root.DataValueField = "ID";
                slct_Root.DataSource = tempStaticPage;
                slct_Root.DataBind();

                #endregion
            }

        }

        private void BindGridView()
        {
            long rowCount = 0;
            var dataSource = busTbl_StaticPage.getAllPage(out rowCount);
            //List<Tbl_StaticPage> staticPage = (from p in dataSource
            //                                  select new Tbl_StaticPage
            //                                  {
            //                                      ID = p.ID,
            //                                      Title = p.CategoryID == 0 ? p.Title : dataSource.Single(o => o.ID == p.CategoryID).Title + $"-{p.Title}",
            //                                      Link = p.CategoryID == 0 ? p.Title : dataSource.Single(o => o.ID == p.CategoryID).Title + $" ---> <a target=\"_blank\" href=\"/CMSPages.aspx/{p.Title.Replace(" ", "_")}\">{p.Title}</a>",
            //                                      Auther = p.Auther,
            //                                      Content = p.Content,
            //                                      Date = p.Date,
            //                                      MasterID = p.MasterID,
            //                                      CategoryID = p.CategoryID
            //                                  }).ToList<Tbl_StaticPage>();
            if (dataSource.Any())
            {
                gvStaticPagesInfo.DataSource = dataSource;
                gvStaticPagesInfo.DataBind();
                gvStaticPagesInfo.UseAccessibleHeader = true;
                gvStaticPagesInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                gvStaticPagesInfo.Columns.Clear();

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dr = dt.NewRow();
                dr["Col1"] = "رکوردی برای نمایش وجود ندارد";

                dt.Rows.Add(dr);

                gvStaticPagesInfo.DataSource = dt;
                gvStaticPagesInfo.DataBind();
            }
        }

        protected void gvStaticPagesInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvStaticPagesInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvStaticPagesInfo.Rows[e.RowIndex].Cells[0].Text); //cells 0 mean id
            busTbl_StaticPage.DeleteOneStaticPages(id);
            BindGridView();
        }

        protected void gvStaticPagesInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //            gvStaticPagesInfo.SetEditRow(-1);
            int id = Convert.ToInt32(gvStaticPagesInfo.Rows[e.NewEditIndex].Cells[0].Text); //cells 0 mean id
            hfselectedPageForEdit.Value = id.ToString();
            var staticPageEdit = busTbl_StaticPage.getPage(id);
            if (staticPageEdit != null && staticPageEdit.ID > 0)
            {
                AddStaticPage.Visible = false;
                EditStaticPage.Visible = true;
                cancelEditing.Visible = true;
                txtPageTitle.Value = staticPageEdit.Title;
                txtPageAuther.Value = staticPageEdit.Auther;
                slct_master.SelectedIndex = slct_master.Items.IndexOf(slct_master.Items.FindByValue(staticPageEdit.MasterID.ToString()));
                txtPageContent.Text = staticPageEdit.Content;
                if (staticPageEdit.CategoryID == 0)
                    is_Root.Checked = true;
                else is_Root.Checked = false;
                slct_Root.Items.Remove(slct_Root.Items.FindByValue(staticPageEdit.ID.ToString()));
                slct_Root.SelectedIndex = slct_Root.Items.IndexOf(slct_Root.Items.FindByValue(staticPageEdit.CategoryID.ToString()));
            }

            //            BindGridView();
            gvStaticPagesInfo.DataSource = null;
            gvStaticPagesInfo.DataBind();
        }

        protected void EditStaticPages_OnServerClick(object sender, EventArgs e)
        {
            if (hfselectedPageForEdit.Value != null)
            {
                int id = Convert.ToInt32(hfselectedPageForEdit.Value);
                Tbl_StaticPage sp = new Tbl_StaticPage
                {
                    Title = txtPageTitle.Value,
                    Auther = txtPageAuther.Value,
                    MasterID = Convert.ToInt32(slct_master.Value),
                    CategoryID = is_Root.Checked ? 0 : Convert.ToInt32(slct_Root.Value),
                    Content = txtPageContent.Text,
                };
                var staticPagesEdit = busTbl_StaticPage.UpdateOneStaticPage(id, sp);
                if (staticPagesEdit)
                {
                    AddStaticPage.Visible = true;
                    EditStaticPage.Visible = false;
                    Response.Redirect("GenerateStaticPages.aspx", true);
                }
            }
        }

        protected void cancelEditing_OnServerClick(object sender, EventArgs e)
        {
            Response.Redirect("GenerateStaticPages.aspx", true);
        }

        protected void AddStaticPage_OnServerClick(object sender, EventArgs e)
        {
            Tbl_StaticPage page = new Tbl_StaticPage
            {
                Title = txtPageTitle.Value,
                Auther = txtPageAuther.Value,
                MasterID = Convert.ToInt32(slct_master.Value),
                CategoryID = is_Root.Checked ? 0 : Convert.ToInt32(slct_Root.Value),
                Content = txtPageContent.Text,
                Date = DateTime.Now,
            };
            busTbl_StaticPage.addNewPage(page);
            Response.Redirect("GenerateStaticPages.aspx", true);

        }
    }
}