using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
namespace Esra.WebUI.admin
{
    public partial class FirstPageEditSection : System.Web.UI.Page
    {
        private static int SelectedSectionIdForEdit = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDropDownList();
            }
        }

        protected void AddPageSection_OnServerClick(object sender, EventArgs e)
        {
            Tbl_FirstPageSection firstPageSection = new Tbl_FirstPageSection
            {
                Title = txtNewTitle.Value,
                Title2 = txtNewTitle2.Value,
                Descrip = hfNewDescrip.Value,
                ContinueLink = txtNewContinueLink.Value,
                ImgUrl = SaveFile(FileUploadNewImgUrl)
            };
            int id = busTbl_firstPageSection.InsertOneFirstPageSection(firstPageSection);
            if (id > 0)
            {
                txtNewTitle.Value = "";
                txtNewTitle2.Value = "";
                hfNewDescrip.Value = "";
                txtNewContinueLink.Value = "";
                loadDropDownList();
            }
        }

        protected void EditPageSection_OnServerClick(object sender, EventArgs e)
        {
            Tbl_FirstPageSection pageSection = new Tbl_FirstPageSection
            {
                Title = txtEditTitle.Value,
                Title2 = txtEditTitle2.Value,
                Descrip = hfEditDescrip.Value,
                ContinueLink = txtEditContinueLink.Value,
            };
            busTbl_firstPageSection.UpdateOneFirstPageSection(pageSection, SelectedSectionIdForEdit);
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();

        }

        protected void ddlPageEditSection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlPageEditSection.SelectedItem.Value);
            var firstPageSection = busTbl_firstPageSection.GetAllFirstPageSection(id).SingleOrDefault();
            if (firstPageSection != null)
            {
                SelectedSectionIdForEdit = id;
                txtEditTitle.Value = firstPageSection.Title;
                txtEditTitle2.Value = firstPageSection.Title2;
                txtEditDescrip.InnerHtml = firstPageSection.Descrip;
                txtEditContinueLink.Value = firstPageSection.ContinueLink;
                secEditControls.Visible = true;
                secSelectPageForEdit.Visible = false;
            }
        }

        protected void btnCancelEditing_OnServerClick(object sender, EventArgs e)
        {
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();
        }

        private void loadDropDownList()
        {
            var firstPageSection = busTbl_firstPageSection.GetAllFirstPageSection(0);
            ddlPageEditSection.DataTextField = "Title";
            ddlPageEditSection.DataValueField = "ID";
            ddlPageEditSection.DataSource = firstPageSection;
            ddlPageEditSection.DataBind();
            ddlPageEditSection.Items.Insert(0, new ListItem
            {
                Text = "انتخاب کنید",
                Value = "0",
                Selected = true
            });
        }

        private string SaveFile(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string savePath = Server.MapPath("../IMG/moduleIMG");
                string fileName = fileUpload.FileName;
                string tempfileName = Guid.NewGuid() + Path.GetExtension(fileName);
                string pathToCheck = savePath + "\\" + tempfileName;
                fileUpload.SaveAs(pathToCheck);
                return tempfileName;
            }
            return "";
        }

        protected void btnDeleteEditing_OnServerClick(object sender, EventArgs e)
        {
            if (SelectedSectionIdForEdit > 0)
                busTbl_firstPageSection.DeleteOneFirstPageSection(SelectedSectionIdForEdit);
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();

        }
    }
}