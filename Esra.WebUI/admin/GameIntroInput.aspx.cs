using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
using CKEditor.NET;
using Esra.BUSINESSBpms;


namespace Esra.WebUI.admin
{
    public partial class GameIntroInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region genres

                var genres = busTblCategory.GetAllGenres();
                //                slct_genres.DataTextField = "title";
                //                slct_genres.DataValueField = "id";
                //                slct_genres.DataSource = genres;
                //                slct_genres.DataBind();

                slct_genres2.DataTextField = "Name";
                slct_genres2.DataValueField = "Id";
                slct_genres2.DataSource = genres;
                slct_genres2.DataBind();

                #endregion

                #region platform

                var platform = busPlatforms.GetAllPlatform().Where(p => p.title != "Android");
                //                platform_ver.DataTextField = "title";
                //                platform_ver.DataValueField = "id";
                //                platform_ver.DataSource = platform;
                //                platform_ver.DataBind();


                platform_ver2.DataTextField = "title";
                platform_ver2.DataValueField = "id";
                platform_ver2.DataSource = platform;
                platform_ver2.DataBind();

                #endregion

                #region sources

                var sources = busSources.GetAllSource();
                source_type.DataTextField = "title";
                source_type.DataValueField = "id";
                source_type.DataSource = sources;
                source_type.DataBind();

                #endregion

                #region ages

                var ages = busAges.GetAllAges();
                slct_esra_grade.DataTextField = "title";
                slct_esra_grade.DataValueField = "id";
                slct_esra_grade.DataSource = ages;
                slct_esra_grade.DataBind();

                #endregion

                #region add item to slct

                for (int i = 1; i <= 5; i++)
                {
                    slct_esra_skill.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                    slct_esra_violence.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                    slct_esra_fear.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                    slct_esra_drugs.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                    slct_esra_anomalies.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                    slct_esra_despair.Items.Add(new ListItem(i.ToString(), i.ToString()) { Selected = false });
                }

                slct_esra_skill.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });
                slct_esra_violence.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });
                slct_esra_fear.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });
                slct_esra_drugs.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });
                slct_esra_anomalies.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });
                slct_esra_despair.Items.Insert(0, new ListItem
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                    Selected = true
                });

                #endregion

                EditGameIntroInfo.Visible = false;
                cancelEditing.Visible = false;
                BindGridView();
            }
        }

        private void BindGridView()
        {
            long rowCount = 0;
            var dataSource = busGames_introduction.GetAllGames_introduction(null, out rowCount);
            if (dataSource.Any())
            {
                gvGameIntroInfo.DataSource = dataSource;
                gvGameIntroInfo.DataBind();
                gvGameIntroInfo.UseAccessibleHeader = true;
                gvGameIntroInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                gvGameIntroInfo.Columns.Clear();

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dr = dt.NewRow();
                dr["Col1"] = "رکوردی برای نمایش وجود ندارد";

                dt.Rows.Add(dr);

                gvGameIntroInfo.DataSource = dt;
                gvGameIntroInfo.DataBind();
            }
        }

        protected void gvGameIntroInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvGameIntroInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvGameIntroInfo.Rows[e.RowIndex].Cells[0].Text); //cells 0 mean id
            string imgList = "";
            string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";

            bool gameIntroInfoDeleted = busGames_introduction.DeleteOneGames_introduction(id, out imgList);
            if (gameIntroInfoDeleted)
                if (!string.IsNullOrEmpty(imgList))
                    foreach (string img in imgList.Split(','))
                    {
                        if (File.Exists(gameFolder + id + "\\" + img))
                        {
                            File.Delete(gameFolder + id + "\\" + img);
                        }
                    }
            BindGridView();
        }

        protected void gvGameIntroInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //            gvGameIntroInfo.SetEditRow(-1);
            int id = Convert.ToInt32(gvGameIntroInfo.Rows[e.NewEditIndex].Cells[0].Text); //cells 0 mean id
            hfselectedGameForEdit.Value = id.ToString();
            var gameIntroInfoEdit = busGames_introduction.GetOneGames_introduction(id.ToString(),"").SingleOrDefault();
            if (gameIntroInfoEdit != null && gameIntroInfoEdit.id > 0)
            {
                AddGameIntroInfo.Visible = false;
                EditGameIntroInfo.Visible = true;
                cancelEditing.Visible = true;
                txtGameName.Value = gameIntroInfoEdit.name;
                txtPublisher.Value = gameIntroInfoEdit.publisher;

                foreach (ListItem item in slct_genres2.Items)
                    item.Selected = gameIntroInfoEdit.genreID.Split(',').Contains(item.Value);


                foreach (ListItem item in platform_ver2.Items)
                    item.Selected = gameIntroInfoEdit.platformID.Split(',').Contains(item.Value);

                source_type.SelectedIndex =
                    source_type.Items.IndexOf(source_type.Items.FindByValue(gameIntroInfoEdit.source_id.ToString()));
                txtYearPublished.Value = gameIntroInfoEdit.publish_date.ToString();
                intro_intro.Text = gameIntroInfoEdit.intro_intro;
                intro_short.Text = gameIntroInfoEdit.intro_short;
                intro_gameplay.Text = gameIntroInfoEdit.intro_gameplay;
                txtReviewersScore.Value = gameIntroInfoEdit.reviewers_score.ToString();
                slct_esra_grade.SelectedIndex =
                    slct_esra_grade.Items.IndexOf(
                        slct_esra_grade.Items.FindByValue(gameIntroInfoEdit.esra_grade.ToString()));
                slct_esra_skill.SelectedIndex =
                    slct_esra_skill.Items.IndexOf(
                        slct_esra_skill.Items.FindByValue(gameIntroInfoEdit.esra_skill.ToString()));
                slct_esra_violence.SelectedIndex =
                    slct_esra_violence.Items.IndexOf(
                        slct_esra_violence.Items.FindByValue(gameIntroInfoEdit.esra_violence.ToString()));
                slct_esra_fear.SelectedIndex =
                    slct_esra_fear.Items.IndexOf(slct_esra_fear.Items.FindByValue(gameIntroInfoEdit.esra_fear.ToString()));
                slct_esra_drugs.SelectedIndex =
                    slct_esra_drugs.Items.IndexOf(
                        slct_esra_drugs.Items.FindByValue(gameIntroInfoEdit.esra_drugs.ToString()));
                slct_esra_anomalies.SelectedIndex =
                    slct_esra_anomalies.Items.IndexOf(
                        slct_esra_anomalies.Items.FindByValue(gameIntroInfoEdit.esra_anomalies.ToString()));
                slct_esra_despair.SelectedIndex =
                    slct_esra_despair.Items.IndexOf(
                        slct_esra_despair.Items.FindByValue(gameIntroInfoEdit.esra_despair.ToString()));
                txtPicName.Text = gameIntroInfoEdit.Picture;
                pnl_OldPic.InnerHtml = "";
                foreach (var s in gameIntroInfoEdit.Picture.Split(','))
                {
                    if (!string.IsNullOrEmpty(s))
                        pnl_OldPic.InnerHtml += $"<div class=\"imgContainer\">" +
                                                $"<img class=\"gameLogo\" src=\"/uploads/picture/game/gamePic/{gameIntroInfoEdit.id}/{s}\">" +
                                                $"<div><span class=\"js-delPic\">حذف</span><span>{s}</span></div>" +
                                                $"</div>";
                }
            }

            //            BindGridView();
            gvGameIntroInfo.DataSource = null;
            gvGameIntroInfo.DataBind();
        }

        protected void EditGameIntroInfo_OnServerClick(object sender, EventArgs e)
        {
            if (hfselectedGameForEdit.Value != null)
            {
                string oldPic = txtPicName.Text;
                string newPic = oldPic.Split(',')
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Aggregate("", (current, s) => current + (s + ","));
                int id = Convert.ToInt32(hfselectedGameForEdit.Value);
                deleteImage(id);
                games_introduction gi = new games_introduction
                {
                    name = txtGameName.Value,
                    publisher = txtPublisher.Value,
                    genreID =
                        slct_genres2.Items.Cast<ListItem>()
                            .Where(li => li.Selected == true)
                            .Aggregate("", (current, li) => current + (li.Value + ",")),
                    platformID =
                        platform_ver2.Items.Cast<ListItem>()
                            .Where(li => li.Selected == true)
                            .Aggregate("", (current, li) => current + (li.Value + ",")),
                    source_id = Convert.ToInt32(source_type.Value),
                    publish_date = Convert.ToInt64(txtYearPublished.Value),
                    intro_short = intro_short.Text,
                    intro_intro = intro_intro.Text,
                    intro_gameplay = intro_gameplay.Text,
                    reviewers_score = Convert.ToByte(txtReviewersScore.Value),
                    esra_grade = Convert.ToByte(slct_esra_grade.Value),
                    esra_skill = Convert.ToByte(slct_esra_skill.Value),
                    esra_violence = Convert.ToByte(slct_esra_violence.Value),
                    esra_fear = Convert.ToByte(slct_esra_fear.Value),
                    esra_drugs = Convert.ToByte(slct_esra_drugs.Value),
                    esra_anomalies = Convert.ToByte(slct_esra_anomalies.Value),
                    esra_despair = Convert.ToByte(slct_esra_despair.Value),
                    Picture = newPic.RemoveLastChar(",")
                };

                var gameIntroInfoEdit = busGames_introduction.UpdateOneGames_introduction(id, gi);
                if (gameIntroInfoEdit)
                {
                    AddGameIntroInfo.Visible = true;
                    EditGameIntroInfo.Visible = false;

                    string sessionId = HttpContext.Current.Session.SessionID + "\\";

                    string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";
                    foreach (string img in txtPicName.Text.Split(','))
                    {
                        if (!string.IsNullOrEmpty(img))
                        {
                            string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + img;
                            new FileInfo(gameFolder + id + "\\" + "img").Directory?.Create();
                            try
                            {
                                File.Move(tempFolder, gameFolder + id + "\\" + img);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }

                    Response.Redirect("GameIntroInput.aspx", true);
                }
            }
        }

        private static void deleteImage(int id)
        {
            var lastImg = busGames_introduction.GetOneGames_introduction(id.ToString(),"").Single().Picture;

            string sessionId = HttpContext.Current.Session.SessionID + "\\";

            string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";
            foreach (string img in lastImg.Split(','))
            {
                string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId;
                new FileInfo(tempFolder).Directory?.Create();
                try
                {
                    File.Move(gameFolder + id + "\\" + img, tempFolder + img);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        protected void cancelEditing_OnServerClick(object sender, EventArgs e)
        {
            Response.Redirect("GameIntroInput.aspx", true);
        }
    }
}