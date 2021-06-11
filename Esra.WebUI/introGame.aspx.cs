using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.BUSINESSBpms;
using Esra.COMMON;

namespace Esra.WebUI
{
    public partial class introGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.

            if (!Page.IsPostBack)
            {

                #region queryString proccess

                string gameId = Request.QueryString["gi"];


                #endregion

                #region genres

                var genres = busTblCategory.GetAllGenres();
                ddlGenres.InnerHtml = genres.Aggregate<tblCategory, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                #region ages

                var ages = busTblEsra.GetAllAges().Where(q => q.IdHead == 11 && q.Id != 7);
                ddlAges.InnerHtml = ages.Aggregate<tblEsra, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option  id=\"{itemContent.Id}\">{itemContent.Age}+</option>");

                #endregion

                #region platform

                var platform = busTblPlatform.GetAllPlatform().Where(x => x.Id <= 8);
                ddlGamePlatform.InnerHtml = platform.Aggregate<tblPlatform, string>(null, (current, itemContent) => current + $"<option id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                #region sources
                var sources = busSources.GetAllSource();
                #endregion
                var gamesIntroductions = busVwIntroductionGameResults.GetOneGames_introduction(gameId, "");

                #region load related intro Game
                long rowCount = 0;
                int pageSize = 10;
                var p = busVwIntroductionGameResults.GetRelatedGames_introduction(gameId);
                if (p != null)
                    foreach (vwIntroductionGameResult result in p)
                    {
                        string mainImg = "";
                        if (!string.IsNullOrEmpty(result.Picture))
                        {
                            string[] allImg = result.Picture.Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
                            Array.Sort(allImg);
                            if (allImg.Any())
                                mainImg = allImg[0];

                        }
                        string agesTitle = ages.SingleOrDefault(q => q.Id == result.esra_grade)?.Age;
                        //string platformsTitle = platform.SingleOrDefault(q => q.id == result.platformID)?.title;
                        string platformsTitle = result.platformID.Split(',').Aggregate("", (current, pi) => current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));

                        string pattern = "<[^>]*>";
                        Regex rgx = new Regex(pattern);
                        string continueLink = $"<a href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";
                        searchResult.InnerHtml +=
                            $"<div class=\"search-result-temp1\">" +
                                $"<a href=\"{"introGame.aspx?gi=" + result.id}\">" +
                                    $"<div class=\"img-search-result\">" +
                                        $"<span data-tilt alt=\"\" class=\"img-search-result-rate _{agesTitle}RateB\"></span>" +
                                        $"<img data-tilt style=\"position:absolute;\" src=\"/uploads/picture/game/gamePic/{result.id}/{result.PictureCover}\" alt=\"\" class=\"img-search-result \" />" +
                                    $"</div>" +
                                $"</a>" +
                            $"<div class=\"result-game-info\"><div class=\"game-info\">" +
                                $"<p>نام بازی</p>" +
                                $"<p class=\"_{agesTitle}RateC\">" +
                                    $"<a href=\"{"introGame.aspx?gi=" + result.id}\">{result.name}</a>" +
                                $"</p>" +
                                $"<p>پلتفرم</p>" +
                                $"<p>{platformsTitle.RemoveLastChar(",").Replace(",", "،")}</p>" +
                                $"<p>سال</p><p>{result.publish_date.Year}</p>" +
                                $"<p>شرکت سازنده</p><p>{result.publisher}</p>" +
                            $"</div>" +
                            $"<div class=\"game-type\">" +
                                $"{(result.esra_skill > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_skill{result.esra_skill}.png\">" : "")}" +
                                $"{(result.esra_violence > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_violence{result.esra_violence}.png\">" : "")}" +
                                $"{(result.esra_fear > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_fear{result.esra_fear}.png\">" : "")}" +
                                $"{(result.esra_drugs > 0 ? $"<img data-tilt src=\"/admin/IMG/drugs{result.esra_drugs}.png\">" : "")}" +
                                $"{(result.esra_anomalies > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_anomalies{result.esra_anomalies}.png\">" : "")}" +
                                $"{(result.esra_despair > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_despair{result.esra_despair}.png\">" : "")}";
                        searchResult.InnerHtml += $"</div>" +
                    $"</div>" +
                    $"<div class=\"result-game-describe\">" +
                                                  $"<p class=\"game-describe\">{rgx.Replace(result.intro_gameplay, "").WordCountToShow(50, false) + continueLink}</p>" +
                                                  $"</div>" +
                                                  $"</div>";

                    }
                if (gamesIntroductions != null)
                {
                    var gamesIntroduction = gamesIntroductions.FirstOrDefault();
                    if (gamesIntroduction != null)
                    {
                        string platformName = gamesIntroduction.platformID;
                        string genresName = gamesIntroduction.genreID;
                        string age = gamesIntroductions[0].esra_grade.ToString();
                        relatedGameLink.HRef = $"/introGameResults.aspx?g={genresName}&a={age}&pf={platformName}&s=GameName";
                    }
                }
                #endregion

                #region load intro game


                if (gamesIntroductions != null && gamesIntroductions.Count == 1)
                {
                    var gamesIntroduction = gamesIntroductions.FirstOrDefault();
                    string Img = "";

                    if (!string.IsNullOrEmpty(gamesIntroduction.Picture))
                    {
                        string[] allImg = gamesIntroduction.Picture.Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
                        Array.Sort(allImg);
                        if (allImg.Any())
                            Img += $"<img   class=\" height100 gameLargLogo\" src=\"uploads/picture/game/gamePic/{gamesIntroduction.id}/{gamesIntroduction.PictureCover}\">";

                        foreach (string img in allImg)
                        {
                            if (!string.IsNullOrEmpty(img))
                                Img += $"<img   class=\" height100 gameLargLogo\" src=\"uploads/picture/game/gamePic/{gamesIntroduction.id}/{img }\">";


                        }

                    }
                    //string platformName = platform.SingleOrDefault(q => q.id == gamesIntroduction.platformID)?.title;
                    string platformName = gamesIntroduction.platformID.Split(',').Aggregate("", (current, pi) => current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string genresName = gamesIntroduction.genreID.Split(',').Aggregate("", (current, pi) => current + (genres.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));

                    string pattern = "<[^>]*>";
                    Regex rgx = new Regex(pattern);

                    string persinStyle = "style=\"direction: rtl;text-align: right;\"";
                    string englishStyle = "style=\"direction: ltr;text-align: left;\"";

                    string agesName = ages.SingleOrDefault(q => q.Id == gamesIntroduction.esra_grade)?.Age;
                    string sourcesName = sources.SingleOrDefault(q => q.id == gamesIntroduction.source_id)?.title;


                    gameIntro.InnerHtml = "";

                    gameIntro.InnerHtml =
                        $"<div class=\"flL gameLargLogoHolder\">{Img} <hr/><div>" + gamesIntroduction.AparatLink + "</div></div>" +
                        $"<div class=\"flR contCent height100 \">" +
                        $"<div class=\"divGameIntro _{agesName}RateB\">" +
                        $"<p {(gamesIntroduction.name.isPersian() ? persinStyle : englishStyle)} class=\"_{agesName}RateC\">{gamesIntroduction.name}</p>" +
                        $"<p style=\"font-size:11px;font-family:iransansbold;\" class=\"intro\">{rgx.Replace(gamesIntroduction.intro_short, "")}</p>" +


                        $"<div><p class=\"b0b0b0\">سبک بازی: </p><p class=\"cll\">{genresName.RemoveLastChar(",")}</p></div>" +
                        $"<div><p class=\"b0b0b0\">پلتفرم: </p><p class=\"cll\">{platformName.RemoveLastChar(",").Replace(",", "،")}</p></div>" +
                        $"<div><p class=\"b0b0b0\">سال: </p><p class=\"cll\">{gamesIntroduction.publish_date.Year}</p></div>" +
                        $"<div><p class=\"b0b0b0\">شرکت سازنده: </p><p class=\"cll\">{gamesIntroduction.publisher}</p></div>" +
                        //$"<div><p class=\"b0b0b0\">نوع سورس: </p><p class=\"cll\">{gamesIntroduction.sourceName}</p></div>" +
                        $"<p class=\"intro\">{rgx.Replace(gamesIntroduction.intro_gameplay, "")}</p>" +
                        $"{(gamesIntroduction.esra_skill > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_skill{gamesIntroduction.esra_skill}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_violence > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_violence{gamesIntroduction.esra_violence}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_fear > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_fear{gamesIntroduction.esra_fear}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_drugs > 0 ? $"<img data-tilt src=\"/admin/IMG/drugs{gamesIntroduction.esra_drugs}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_anomalies > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_anomalies{gamesIntroduction.esra_anomalies}.png\">" : "")}" +
                        $"{(gamesIntroduction.esra_despair > 0 ? $"<img data-tilt src=\"/admin/IMG/esra_despair{gamesIntroduction.esra_despair}.png\">" : "")}" +
                        $"<p class=\"intro\">{rgx.Replace(gamesIntroduction.ParentRecommendation, "")}</p>" +

                        $"</div></div>";
                }
                #endregion
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            var gameName = txtSearchGameName.Text;
            var hfSearchGenre = hfSearchGenres.Value.RemoveLastChar(",");
            var hfSearchAge = hfSearchAges.Value.RemoveLastChar(",");
            var hfSearchPlatfor = hfSearchPlatform.Value.RemoveLastChar(",");

            if (hfSearchGenre == "0") hfSearchGenre = "";
            if (hfSearchAge == "0") hfSearchAge = "";
            if (hfSearchPlatfor == "0") hfSearchPlatfor = "";

            Response.Redirect(
                $"introGameResults.aspx?gn={gameName}&g={hfSearchGenre}&a={hfSearchAge}&pf={hfSearchPlatfor}&cp=1",
                false);
        }
    }
}