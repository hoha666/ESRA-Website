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
    public partial class GameIntroInputBpms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                EditGameIntroInfo.Visible = false;
                cancelEditing.Visible = false;
                BindGridView();
            }
        }

        private void BindGridView()
        {
            long rowCount = 0;
            IEnumerable<vwIntroductionGameResult> dataSource;
            if (Request.QueryString["mode"] == "edit")
                dataSource = busVwIntroductionGameResults.GetAllGames_introduction(null, out rowCount).Where(p => p.intro_gameplay != "");
            else
                dataSource = busVwIntroductionGameResults.GetAllGames_introduction(null, out rowCount).Where(p => p.intro_gameplay == "");

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
            var gameIntroInfoEdit = busVwIntroductionGameResults.GetOneGames_introduction(id.ToString(), "").SingleOrDefault();
            if (gameIntroInfoEdit != null && gameIntroInfoEdit.id > 0)
            {
                AddGameIntroInfo.Visible = false;
                EditGameIntroInfo.Visible = true;
                cancelEditing.Visible = true;



                bool isAndroid = gameIntroInfoEdit.platformsTitle == "android" ? true : false;

                intro_short.Text = gameIntroInfoEdit.intro_short;
                intro_gameplay.Text = gameIntroInfoEdit.intro_gameplay;
                parentRecomandation.Text = gameIntroInfoEdit.ParentRecommendation;
                txtPicName.Text = gameIntroInfoEdit.Picture + "," + gameIntroInfoEdit.PictureCover;

                pnl_OldPic.InnerHtml = "";
                foreach (var s in gameIntroInfoEdit.Picture.Split(','))
                {
                    if (!string.IsNullOrEmpty(s))
                        if (gameIntroInfoEdit.platformsTitle == "android")
                            pnl_OldPic.InnerHtml += $"<div class=\"imgContainer\">" +
                                                    $"<img class=\"gameLogo\" src=\"/uploads/picture/game/icons/{gameIntroInfoEdit.id}/{s}\">" +
                                                    $"<div>" +
                                                    $"<span class=\"js-delPic\">حذف</span><span>{s}</span>" +
                                                    $"</div>" +
                                                    $"</div>";
                        else
                            pnl_OldPic.InnerHtml += $"<div class=\"imgContainer\">" +
                                                    $"<img class=\"gameLogo\" src=\"/uploads/picture/game/gamePic/{gameIntroInfoEdit.id}/{s}\">" +
                                                    $"<div>" +
                                                    $"<span class=\"js-delPic\">حذف</span><span>{s}</span>" +
                                                    $"<span class=\"js-IsCover\" >کاور</span><span style=\"display:none;\">{s}</span>" +
                                                    $"</div>" +
                                                    $"</div>";
                }
                var pictureCover = gameIntroInfoEdit.PictureCover?.Split(',');
                if (!isAndroid)
                    if (pictureCover != null)
                        foreach (var s in pictureCover)
                        {
                            if (!string.IsNullOrEmpty(s))
                                pnl_OldPic.InnerHtml += $"<div class=\"imgContainer\">" +
                                                        $"<img class=\"gameLogo\" src=\"/uploads/picture/game/gamePic/{gameIntroInfoEdit.id}/{s}\">" +
                                                        $"<div>" +
                                                        $"<span class=\"js-delPic\">حذف</span><span>{s}</span>" +
                                                        $"<span class=\"js-IsCover isCover\" style=\"background-color:green;\">کاور</span><span style=\"display:none;\">{s}</span>" +
                                                        $"</div>" +
                                                        $"</div>";
                        }
            }
            var Show = busTblGame.GetOneTblGameById(id).ShowInEsraWebsite;
            if (Show != null)
                chbShowInEsraWebsite.Checked = Show == true ? true : false;
            else chbShowInEsraWebsite.Checked = false;

            var platformm = gameIntroInfoEdit.platformID.Split(',');
            var platform = busTblPlatform.GetAllPlatform().Where(p => platformm.Contains(p.Id.ToString()));
            platforms.DataTextField = "Name";
            platforms.DataValueField = "Id";
            platforms.DataSource = platform;
            platforms.DataBind();
            platforms.Items[0].Selected = true;
            gvGameIntroInfo.DataSource = null;
            gvGameIntroInfo.DataBind();
        }

        protected void EditGameIntroInfo_OnServerClick(object sender, EventArgs e)
        {
            if (hfselectedGameForEdit.Value != null)
            {
                var currentPicinSite = txtPicName.Text.Split(',')
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList();



                string cover = txtPicCover.Text;
                int idGame = Convert.ToInt32(hfselectedGameForEdit.Value);
                var game = busVwIntroductionGameResults.GetOneGames_introduction(idGame.ToString(), "").SingleOrDefault();
                
                bool isAndroid = game.platformsTitle == "android" ? true : false;
                deleteImage(idGame, isAndroid);
                tblVersion gi = new tblVersion
                {
                    IntroductionMin = intro_short.Text,
                    GamePlay = intro_gameplay.Text,
                    ParentRecommendation = parentRecomandation.Text,
                };

                var gameIntroInfoEdit = busVersion.UpdateOneVersion(idGame, Convert.ToInt32(platforms.SelectedValue), gi);
                if (gameIntroInfoEdit != null)
                {
                    AddGameIntroInfo.Visible = true;
                    EditGameIntroInfo.Visible = false;
                    string sessionId = HttpContext.Current.Session.SessionID + "\\";
                    string gameFolder = isAndroid
                                        ? HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\icons\\"
                                        : HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";
                    foreach (string img in txtPicName.Text.Split(','))
                    {
                        if (!string.IsNullOrEmpty(img))
                        {
                            string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + img;
                            new FileInfo(gameFolder + idGame + "\\" + img).Directory?.Create();
                            try
                            {
                                File.Move(tempFolder, gameFolder + idGame + "\\" + img);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                    }
                    var ShouldDeleteImg = (game.Picture + "," + game.PictureCover).Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList().Except(currentPicinSite);
                    foreach (string img in ShouldDeleteImg)
                    {
                        var file = busTblFile.GetOnetblFiles(img);
                        //if (file!= null)
                        //    for (int i = 0; i < file.Count; i++)
                        //    {
                        //        busTblVersionScreenshot.DeleteOnetblVersionScreenshot(gameIntroInfoEdit.Id, file[i].Id);
                        //        busTblFile.DeleteOnetblFiles(0, img);
                        //    }
                        if (file != null || file.Id != null)
                        {
                            busTblVersionScreenshot.DeleteOnetblVersionScreenshot(gameIntroInfoEdit.Id, file.Id);
                            busTblFile.DeleteOnetblFiles(0, img);
                        }
                    }
                    foreach (string s in currentPicinSite)
                        if (busTblFile.GetOnetblFiles(s) == null)
                        {
                            var idFile = busTblFile.InsertOnetblFiles(new tblFile { Name = s, UploadDateTime = DateTime.Now });
                            busTblVersionScreenshot.InsertOnetblVersionScreenshot(new tblVersionScreenshot
                            {
                                IdFile = idFile,
                                IdVersion = gameIntroInfoEdit.Id,
                                IdScreenshotType = isAndroid ? 7 : 2
                            });
                        }


                    if (!isAndroid)
                    {
                        tblFile file = busTblFile.GetOnetblFiles(cover);
                        busTblVersionScreenshot.UpdateOnetblVersionScreenshot(gameIntroInfoEdit.Id, file.Id);
                    }
                    busTblGame.UpdateOneTblGameById(idGame, new tblGame { ShowInEsraWebsite = chbShowInEsraWebsite.Checked });

                    if (Request.QueryString["mode"] == "edit")
                        Response.Redirect("GameIntroInputBpms.aspx?mode=edit", true);
                    else
                        Response.Redirect("GameIntroInputBpms.aspx?mode=new", true);
                }
            }
        }

        private static void deleteImage(int id, bool isAndroid)
        {
            var game = busVwIntroductionGameResults.GetOneGames_introduction(id.ToString(), "").Single();
            string lastImg = "", gameFolder = "";
            lastImg = isAndroid ? game.Picture : $"{game.Picture},{game.PictureCover}";


            string sessionId = HttpContext.Current.Session.SessionID + "\\";

            gameFolder = isAndroid
                ? HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\icons\\"
                : HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";

            foreach (string img in lastImg.Split(','))
            {
                string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId;
                new FileInfo(tempFolder).Directory?.Create();
                try
                {
                    File.Move(gameFolder + id + "\\" + img, tempFolder + img);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }

        protected void cancelEditing_OnServerClick(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "edit")
                Response.Redirect("GameIntroInputBpms.aspx?mode=edit", true);
            else
                Response.Redirect("GameIntroInputBpms.aspx?mode=new", true);
        }
    }
}