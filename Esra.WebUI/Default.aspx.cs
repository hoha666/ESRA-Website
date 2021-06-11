using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using Esra.BUSINESS;
using Esra.BUSINESSBpms;
using Esra.COMMON;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace Esra.WebUI
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region genres

                var genres = busTblCategory.GetAllGenres();
                ddlGenres.InnerHtml = genres.Aggregate<tblCategory, string>(null,
                    (current, itemContent) => current + $"<option id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                #region ages

                var ages = busTblEsra.GetAllAges().Where(q => q.IdHead == 11 && q.Id != 7);
                ddlAges.InnerHtml = ages.Aggregate<tblEsra, string>(null,
                    (current, itemContent) => current + $"<option id=\"{itemContent.Id}\">{itemContent.Age}+</option>");

                #endregion
                #region kind

                //var kind = busTblPlatform.GetAllPlatform().Where(x => x.Id <= 8);
                //ddlKind.InnerHtml = kind.Aggregate<tblPlatform, string>(null, (current, itemContent) => current + $"<option id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion
                #region platform

                var platform = busTblPlatform.GetAllPlatform().Where(x => x.Id <= 8);
                ddlGamePlatform.InnerHtml = platform.Aggregate<tblPlatform, string>(null, (current, itemContent) => current + $"<option id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                #region Get last 4 Rated Game

                long ratingGameRowCount = 0;
                secLast4RatedGame.InnerHtml = "";
                myCommon.pager ratingGamePager = new myCommon.pager { Take = 6 };
                var ratingGame = busVwRatingGameResult.GetAllRatingGameResult("", "", "1,2,3,4,5,6,7,9,10,11,12,13,14,15", "", ratingGamePager, out ratingGameRowCount, "LastGame");
                int ratingGameindex = 0;
                int[] nums = { 2, 1, 0, 5, 4, 3 };

                for (int i = 0; i < 2; i++)
                {
                    secLast4RatedGame.InnerHtml += $"<div class=\"hrow\">";
                    for (int k = 0; k < 3; k++)
                    {
                        vwRatingGameResults_ result = ratingGame[nums[ratingGameindex]];
                        ratingGameindex++;
                        string ConfirmedPublishers = "";
                        int cpCount = 0;
                        string ConnString = WebConfigurationManager.AppSettings["CloudNasirConnectionString"];
                        string SqlString = "Select * From func_getConfirmedPublishers( @gameId )";
                        using (SqlConnection conn = new SqlConnection(ConnString))
                        {
                            using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("gameId", result.gameId);

                                //conn.Open();
                                DataTable dt = new DataTable();
                                SqlDataAdapter mysqlAdapter = new SqlDataAdapter(cmd);
                                mysqlAdapter.SelectCommand = cmd;
                                mysqlAdapter.Fill(dt);
                                for (int j = 0; j < dt.Rows.Count && dt != null; j++)
                                {
                                    ConfirmedPublishers += dt.Rows[j][0].ToString();
                                    if (j != (dt.Rows.Count - 1)) ConfirmedPublishers += " , ";
                                    cpCount++;
                                }
                            }
                        }
                        if (!result.gameName.Contains("<br>"))
                        {
                            result.gameName += "<br>";
                        }
                        // changing name
                        if (result.gameName.Length > 29)
                        {
                            result.gameName = result.gameName.Remove(26, result.gameName.Length - 26);
                            if (result.gameName.Contains("<br>"))
                                result.gameName = "..." + result.gameName;
                            else
                                result.gameName = "..." + result.gameName + " <br>";
                        }

                        if (cpCount > 0)
                        {
                            if (cpCount > 1)
                            {
                                secLast4RatedGame.InnerHtml +=
                            $"<div class=\" hcolumn  {(ratingGameindex > 2 ? "divRate divRate2" : "divRate")}  ffffff _{result.agesTitle}Rate \"><p>نام بازی</p><p class=\"cll _{result.agesTitle}RateC\">{result.gameName}</p><p>پلتفرم</p><p class=\"cll\">{result.platformsTitle}</p><p>تاریخ انتشار</p><p class=\"cll\">{result.ReleaseDateTime.Value.Year}/{result.ReleaseDateTime.Value.Month}</p><p>ناشر مجاز</p><p class=\"cll\"><a class=\"btn\" href=\"#open-modal{result.gameId}\">لیست ناشرین</a> <div id=\"open-modal{result.gameId}\" class=\"modal-window\"><div style=\"direction: rtl; \"> <a  href=\"#\" title=\"Close\" class=\"modal-close\">بستن</a><hr> <div class=\"jizpalavak\" > {ConfirmedPublishers}</div></div></div></div>";
                            }
                            else
                            {
                                secLast4RatedGame.InnerHtml +=
                                                        $"<div class=\"  hcolumn {(ratingGameindex > 2 ? "divRate divRate2" : "divRate")}  ffffff _{result.agesTitle}Rate  \"><p>نام بازی</p><p class=\"cll _{result.agesTitle}RateC\">{result.gameName}</p><p>پلتفرم</p><p class=\"cll\">{result.platformsTitle}</p><p>تاریخ انتشار</p><p class=\"cll\">{result.ReleaseDateTime.Value.Year}/{result.ReleaseDateTime.Value.Month}</p><p>ناشر مجاز</p><p class=\"cll\">{ConfirmedPublishers}</p></div>";
                            }
                        }
                        else
                        {
                            secLast4RatedGame.InnerHtml +=
                                $"<div class=\" hcolumn {(ratingGameindex > 2 ? "divRate divRate2" : "divRate")}  ffffff _{result.agesTitle}Rate  \"><p>نام بازی</p><p class=\"cll _{result.agesTitle}RateC\">{result.gameName}</p><p>پلتفرم</p><p class=\"cll\">{result.platformsTitle}</p><p>تاریخ انتشار</p><p class=\"cll\">{result.ReleaseDateTime.Value.Year}/{result.ReleaseDateTime.Value.Month}</p><p>&nbsp;</p><p class=\"cll\">&nbsp;</p></div>";
                        }



                    }
                    secLast4RatedGame.InnerHtml += $"</div>";


                }


                #endregion

                #region Get last 3 news Game

                secLast3GameNews.InnerHtml = "";
                var firstPageSection = busTbl_firstPageSection.GetAllFirstPageSection(0);
                foreach (Tbl_FirstPageSection result in firstPageSection)
                {
                    secLast3GameNews.InnerHtml +=
                        $"<div class=\"divNews ffffff\"><div class=\"DivNewsImg\" style=\"background: url(IMG/moduleIMG/{result.ImgUrl}) no-repeat\"><div class=\"DivTag2\"></div><div class=\"DivTag\"><p>{result.Title}</p></div></div><p class=\"NewsTitle\">{result.Title2}</p><p class=\"NewsSubTitle\">{result.Descrip}</p><a href=\"{result.ContinueLink}\">ادامه مطلب</a></div>";
                }
                #endregion

                #region Get last 1 news
                var news = busTbl_News.GetAllNews(0, new myCommon.pager { Take = 1 }).SingleOrDefault();
                if (news != null)
                    secLast3GameNews.InnerHtml +=
                        $"<div class=\"divNews ffffff\"><div class=\"DivNewsImg\" style=\"background: url(IMG/News/{news.Picture}) no-repeat\"><div class=\"DivTag2\"></div><div class=\"DivTag\"><p><a href=\"News.aspx\">خبرهای دیگر</a></p></div></div><p class=\"NewsTitle\">{news.Title}</p><p class=\"NewsSubTitle\">{news.Intro}</p><a href=\"News.aspx?nid={news.ID}\">{news.Link}</a></div>";
                #endregion

                #region GetRandom last 1 GameIntro

                long gamesIntroductionRowCount;
                var gamesIntroductions = busVwIntroductionGameResults.GetAllGames_introduction(new myCommon.pager { Take = 10 }, out gamesIntroductionRowCount, "only not mobile");
                if (gamesIntroductions.Any())
                {

                    int newssCount = gamesIntroductions.Count;
                    newssCount = newssCount >= 10 ? 9 : newssCount - 1;
                    bool sw = true;
                    vwIntroductionGameResult gamesIntroduction = gamesIntroductions[new Random().Next(0, newssCount)];
                    string pattern = "<[^>]*>";
                    Regex rgx = new Regex(pattern);

                    string mainImg = "";
                    if (!string.IsNullOrEmpty(gamesIntroduction.Picture))
                    {
                        string[] allImg = gamesIntroduction.Picture.Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
                        Array.Sort(allImg);
                        if (allImg.Any())
                            mainImg = allImg[0];

                    }
                    //string platformName = platform.SingleOrDefault(p => p.id == gamesIntroduction.platformID)?.title;
                    string platformName = gamesIntroduction.platformID.Split(',').Aggregate("", (current, pi) => current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string genresName = gamesIntroduction.genreID.Split(',').Aggregate("", (current, pi) => current + (genres.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string persinStyle = "style=\"direction: rtl;text-align: right;\"";
                    string englishStyle = "style=\"direction: ltr;text-align: left;\"";
                    string agesName = ages.SingleOrDefault(p => p.Id == gamesIntroduction.esra_grade)?.Age.ToString();
                    gameIntro.InnerHtml =
                        $"<img data-tilt class=\" height100 gameLargLogo\" src=\"/uploads/picture/game/gamePic/{gamesIntroduction.id}/{gamesIntroduction.PictureCover}\">" +
                        $"<div class=\"width1000 contCent height100 \">" +
                        $"<div class=\"divGameIntro _{agesName}RateB\">" +
                        $"<div class=\"DivTag2\"></div><div class=\"DivTag\">" +
                        $"<p><a href=\"\\introGameResults.aspx?gn=&g=&a=&pf=1,5,6,7&cp=1&s=LastGame\">معرفی بازی</a></p></div>" +
                        $"<p {(gamesIntroduction.name.isPersian() ? persinStyle : englishStyle)}><a href=\"introGame.aspx?gi={gamesIntroduction.id}\">{gamesIntroduction.name}</a></p>" +
                        $"<p>{platformName.RemoveLastChar(",")} | {genresName.RemoveLastChar(",")}</p>" +
                        $"<p>{rgx.Replace(gamesIntroduction.intro_gameplay, "").WordCountToShow(80, true)}</p>" +
                        $"{(gamesIntroduction.esra_skill > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_skill{gamesIntroduction.esra_skill}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_violence > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_violence{gamesIntroduction.esra_violence}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_fear > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_fear{gamesIntroduction.esra_fear}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_drugs > 0 ? $"<img data-tilt src=\"/admin/IMG/drugs{gamesIntroduction.esra_drugs}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_anomalies > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_anomalies{gamesIntroduction.esra_anomalies}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_despair > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_despair{gamesIntroduction.esra_despair}.png\">" : "")}" +
                        $"</div></div>";
                }
                #endregion
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            //var t = ddlKind.
            var ttt = "";//DropDownList12.SelectedItem.Value;
            var gameName = txtSearchGameName.Text;
            var hfSearchGenre = hfSearchGenres.Value.RemoveLastChar(",");
            var hfSearchAge = hfSearchAges.Value.RemoveLastChar(",");
            var hfSearchPlatfor = hfSearchPlatform.Value.RemoveLastChar(",");
            var hfgk = hfSearchKind.Value.RemoveLastChar(",");

            if (hfSearchGenre == "0") hfSearchGenre = "";
            if (hfSearchAge == "0") hfSearchAge = "";
            if (hfSearchPlatfor == "0") hfSearchPlatfor = "";
            if (hfgk == "0") hfgk = "";
            if (hfgk == "pc")
                hfSearchPlatfor = "1,2,3,4,5,6,7";
            if (hfgk == "mobile")
                hfSearchPlatfor = "8";


            Response.Redirect(
                $"ratingGameResults.aspx?gn={gameName}&g={hfSearchGenre}&a={hfSearchAge}&pf={hfSearchPlatfor}&cp=1&s=LastGame",
                false);
        }

        protected void hfSearchKind_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}