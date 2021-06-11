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
    public partial class Ages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ages

            var ages = busTblEsra.GetAllAges();

            #endregion

            #region platform

            var platform = busTblPlatform.GetAllPlatform();

            #endregion

            long rowCount = 0;
            string sort = "";
            myCommon.pager pager = new myCommon.pager { Take = 2 };

            string pattern = "<[^>]*>";
            Regex rgx = new Regex(pattern);

            #region load related intro Game age 18

            var p18 = busVwIntroductionGameResults.GetRelatedGames_introductionByAge(5);
            if (p18 != null)
                foreach (vwIntroductionGameResult result in p18)
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
                    //                    string platformsTitle = platform.SingleOrDefault(q => q.id == result.platformID)?.title;
                    string platformsTitle = result.platformID.Split(',')
                        .Aggregate("",
                            (current, pi) =>
                                current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string continueLink = $"<a  href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";

                    searchResult18.InnerHtml += MakeModel(agesTitle, result, mainImg, platformsTitle, rgx, continueLink);
                }

            var p5 = busVwRatingGameResult.GetAllRatingGameResult("", "5", "", "", pager, out rowCount, sort);
            foreach (vwRatingGameResults_ result in p5)
                searchResult18_2.InnerHtml +=
                    $"<div class=\"search-result-temp2\"><span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\"></span><div class=\"game-info2\"><p>نام بازی</p><p class=\"_{result.agesTitle}RateC\">{result.gameName}</p><div class=\"item\"><p>سبک بازی</p><p>پلتفرم</p></div><div class=\"item\"><p>{result.genresTitle}</p><p>{result.platformsTitle}</p></div><div class=\"item\"><p>سال</p><p>ناشر</p></div><div class=\"item\"><p>{result.ReleaseDateTime.Value.Year}</p><p>{result.OrganizationName}</div></div></div>";

            #endregion

            #region load related intro Game age 15

            var p15 = busVwIntroductionGameResults.GetRelatedGames_introductionByAge(4);
            if (p15 != null)
                foreach (vwIntroductionGameResult result in p15)
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
                    string platformsTitle = result.platformID.Split(',')
                        .Aggregate("",
                            (current, pi) =>
                                current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string continueLink = $"-<a  href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";
                    searchResult15.InnerHtml += MakeModel(agesTitle, result, mainImg, platformsTitle, rgx, continueLink);
                }
            var p4 = busVwRatingGameResult.GetAllRatingGameResult("", "4", "", "", pager, out rowCount, sort);
            foreach (vwRatingGameResults_ result in p4)
                searchResult15_2.InnerHtml +=
                    $"<div class=\"search-result-temp2\"><span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\"></span><div class=\"game-info2\"><p>نام بازی</p><p class=\"_{result.agesTitle}RateC\">{result.gameName}</p><div class=\"item\"><p>سبک بازی</p><p>پلتفرم</p></div><div class=\"item\"><p>{result.genresTitle}</p><p>{result.platformsTitle}</p></div><div class=\"item\"><p>سال</p><p>ناشر</p></div><div class=\"item\"><p>{result.ReleaseDateTime.Value.Year}</p><p>{result.OrganizationName}</div></div></div>";

            #endregion

            #region load related intro Game age 12

            var p12 = busVwIntroductionGameResults.GetRelatedGames_introductionByAge(3);
            if (p12 != null)
                foreach (vwIntroductionGameResult result in p12)
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
                    string platformsTitle = result.platformID.Split(',')
                        .Aggregate("",
                            (current, pi) =>
                                current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string continueLink = $"-<a  href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";
                    searchResult12.InnerHtml += MakeModel(agesTitle, result, mainImg, platformsTitle, rgx, continueLink);
                }
            var p3 = busVwRatingGameResult.GetAllRatingGameResult("", "3", "", "", pager, out rowCount, sort);
            foreach (vwRatingGameResults_ result in p3)
                searchResult12_2.InnerHtml +=
                    $"<div class=\"search-result-temp2\"><span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\"></span><div class=\"game-info2\"><p>نام بازی</p><p class=\"_{result.agesTitle}RateC\">{result.gameName}</p><div class=\"item\"><p>سبک بازی</p><p>پلتفرم</p></div><div class=\"item\"><p>{result.genresTitle}</p><p>{result.platformsTitle}</p></div><div class=\"item\"><p>سال</p><p>ناشر</p></div><div class=\"item\"><p>{result.ReleaseDateTime.Value.Year}</p><p>{result.OrganizationName}</div></div></div>";

            #endregion

            #region load related intro Game age 7

            var p7 = busVwIntroductionGameResults.GetRelatedGames_introductionByAge(2);
            if (p7 != null)
                foreach (vwIntroductionGameResult result in p7)
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
                    string platformsTitle = result.platformID.Split(',')
                        .Aggregate("",
                            (current, pi) =>
                                current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string continueLink = $"<a href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";
                    searchResult7.InnerHtml += MakeModel(agesTitle, result, mainImg, platformsTitle, rgx, continueLink);
                }
            var p2 = busVwRatingGameResult.GetAllRatingGameResult("", "2", "", "", pager, out rowCount, sort);
            foreach (vwRatingGameResults_ result in p2)
                searchResult7_2.InnerHtml +=
                    $"<div class=\"search-result-temp2\"><span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\"></span><div class=\"game-info2\"><p>نام بازی</p><p class=\"_{result.agesTitle}RateC\">{result.gameName}</p><div class=\"item\"><p>سبک بازی</p><p>پلتفرم</p></div><div class=\"item\"><p>{result.genresTitle}</p><p>{result.platformsTitle}</p></div><div class=\"item\"><p>سال</p><p>ناشر</p></div><div class=\"item\"><p>{result.ReleaseDateTime.Value.Year}</p><p>{result.OrganizationName}</div></div></div>";

            #endregion

            #region load related intro Game age 3

            var p33 = busVwIntroductionGameResults.GetRelatedGames_introductionByAge(1);
            if (p33 != null)
                foreach (vwIntroductionGameResult result in p33)
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
                    string platformsTitle = result.platformID.Split(',')
                        .Aggregate("",
                            (current, pi) =>
                                current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                    string continueLink = $"-<a href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";
                    searchResult3.InnerHtml += MakeModel(agesTitle, result, mainImg, platformsTitle, rgx, continueLink);
                }
            var p1 = busVwRatingGameResult.GetAllRatingGameResult("", "1", "", "", pager, out rowCount, sort);
            foreach (vwRatingGameResults_ result in p1)
                searchResult3_2.InnerHtml +=
                    $"<div class=\"search-result-temp2\"><span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\"></span><div class=\"game-info2\"><p>نام بازی</p><p class=\"_{result.agesTitle}RateC\">{result.gameName}</p><div class=\"item\"><p>سبک بازی</p><p>پلتفرم</p></div><div class=\"item\"><p>{result.genresTitle}</p><p>{result.platformsTitle}</p></div><div class=\"item\"><p>سال</p><p>ناشر</p></div><div class=\"item\"><p>{result.ReleaseDateTime.Value.Year}</p><p>{result.OrganizationName}</div></div></div>";

            #endregion
        }

        public static string MakeModel(string agesTitle, vwIntroductionGameResult result, string mainImg, string platformsTitle, Regex rgx, string continueLink)
        {
            string tempS = "";
            tempS +=
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
            tempS += $"</div>" +
                     $"</div>" +
                     $"<div class=\"result-game-describe\">" +
                     $"<p class=\"game-describe\">{rgx.Replace(result.intro_gameplay, "").WordCountToShow(50, false) + continueLink}</p>" +
                     $"</div>" +
                     $"</div>";
            return tempS;
        }
    }
}