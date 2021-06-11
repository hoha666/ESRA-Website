using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;

namespace Esra.WebUI.admin
{
    public partial class News : System.Web.UI.Page
    {
        private static int _selectedNewsIdForEdit = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDropDownList();
                var allNewsCategory = busTbl_NewsCategory.GetAllNewsCategories(0);
                PopulateTreeView(NewsCategoryList, 0, allNewsCategory);
            }
        }


        protected void btnAddNewNews_OnServerClick(object sender, EventArgs e)
        {
            int newsCategory = 0;
            if (!string.IsNullOrEmpty(hfNewsCategoryList.Value.Replace("tag_", "")))
                newsCategory = Convert.ToInt32(hfNewsCategoryList.Value.Replace("tag_", "").Replace(",", ""));
            Tbl_New news = new Tbl_New
            {
                Title = txtNewsTitle.Value,
                Intro = txtNewsIntro.Value,
                Content = txtNewsContent.Text,
                Auther = txtNewsAuther.Value,
                Created = DateTime.Now,
                Picture = SaveFile(fileUploadPicture),
                Tag = hfNewsTag.Value,
                IsEdited = false,
                IsDeleted = false,
                IsArchived = false,
                EditedNewsID = 0,
                NewsCategoryID = newsCategory,
                Link = txtNewsLink.Value,
            };
            int id = busTbl_News.InsertOneNews(news);
            if (id > 0)
            {
                txtNewsTitle.Value = "";
                txtNewsIntro.Value = "";
                txtNewsContent.Text = "";
                txtNewsAuther.Value = "";
                hfNewsTag.Value = "";
                txtNewsLink.Value = "";
                loadDropDownList();
            }
        }

        private string SaveFile(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string savePath = Server.MapPath("../IMG/News");
                string fileName = fileUpload.FileName;
                string tempfileName = Guid.NewGuid() + Path.GetExtension(fileName);
                string pathToCheck = savePath + "\\" + tempfileName;
                fileUpload.SaveAs(pathToCheck);
                return tempfileName;
            }
            return "";
        }

        private void loadDropDownList()
        {
            var News = busTbl_News.GetAllNews(0);
            ddlNewsList.DataTextField = "Title";
            ddlNewsList.DataValueField = "ID";
            ddlNewsList.DataSource = News;
            ddlNewsList.DataBind();
            ddlNewsList.Items.Insert(0, new ListItem
            {
                Text = "انتخاب کنید",
                Value = "0",
                Selected = true
            });
        }

        protected void ddlNewsList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlNewsList.SelectedItem.Value);
            var news = busTbl_News.GetAllNews(id).SingleOrDefault();
            if (news != null)
            {
                _selectedNewsIdForEdit = id;
                txtNewsEditTitle.Value = news.Title;
                txtNewsEditIntro.Value = news.Intro;
                txtNewsEditContent.Text = news.Content;
                txtNewsEditAuther.Value = news.Auther;
                txtNewsEditTag.Value = news.Tag;
                //                txtNewsEditCategoryID.Value = news.NewsCategoryID.ToString();
                txtNewsEditLink.Value = news.Link;
                secEditControls.Visible = true;
                secSelectPageForEdit.Visible = false;
            }
        }

        protected void EditNews_OnServerClick(object sender, EventArgs e)
        {
            Tbl_New news = new Tbl_New
            {
                Title = txtNewsEditTitle.Value,
                Intro = txtNewsEditIntro.Value,
                Content = txtNewsEditContent.Text,
                Auther = txtNewsEditAuther.Value,
                Created = DateTime.Now,
                //                Picture = SaveFile(fileUploadPicture),
                Tag = txtNewsEditTag.Value,
                IsEdited = true,
                IsDeleted = false,
                IsArchived = false,
                EditedNewsID = 0,
                Link = txtNewsEditLink.Value,
            };
            busTbl_News.UpdateOneNews(news, _selectedNewsIdForEdit);
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();
        }

        protected void btnCancelNews_OnServerClick(object sender, EventArgs e)
        {
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();
        }

        protected void btnDeleteNews_OnServerClick(object sender, EventArgs e)
        {
            if (_selectedNewsIdForEdit > 0)
                busTbl_News.DeleteOneNews(_selectedNewsIdForEdit);
            secSelectPageForEdit.Visible = true;
            secEditControls.Visible = false;
            loadDropDownList();
        }

        protected void PopulateTreeView(HtmlGenericControl parentNode, int parentId, List<Tbl_NewsCategory> dataCategories){
            parentNode.InnerHtml += "<ul>";
            foreach (Tbl_NewsCategory newsCategory in dataCategories)
            {
                if (newsCategory.ParentID == parentId)
                {
                    String value = newsCategory.ID.ToString();
                    String text = newsCategory.Name;
                    parentNode.InnerHtml += $"<li>";
                    parentNode.InnerHtml += $"<span class=\"js-select-tag\" id=\"{"tag_" + value}\">{text}</span>";

                    PopulateTreeView(parentNode, newsCategory.ID, dataCategories);
                }
            }
            parentNode.InnerHtml += "</li></ul>";
        }
    }
}