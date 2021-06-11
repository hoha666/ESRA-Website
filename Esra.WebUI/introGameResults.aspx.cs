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
    public partial class introGameResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var shorterString = "";
            if (!Page.IsPostBack)
            {
                string activedropDown = $"class=\"js-active\"";

                #region queryString proccess

                string gameName = Request.QueryString["gn"];
                string searchGenre = Request.QueryString["g"];
                string searchAge = Request.QueryString["a"];
                string searchPlatfor = Request.QueryString["pf"];
                string category = Request.QueryString["c"];
                string currentPage = Request.QueryString["cp"];
                string sort = Request.QueryString["s"];

                int[] ageIdList = new int[] { };
                int[] platformIdList = new int[] { };
                int[] genreIdList = new int[] { };
                int[] categoryIdList = new int[] { };////is new and need to edit
                int currentPageInt = 1;
                if (!string.IsNullOrEmpty(searchAge)) ageIdList = searchAge.RemoveLastChar(",").Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(searchPlatfor)) platformIdList = searchPlatfor.RemoveLastChar(",").Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(searchGenre)) genreIdList = searchGenre.RemoveLastChar(",").Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(category)) categoryIdList = category.RemoveLastChar(",").Split(',').Select(int.Parse).ToArray();////is new and need to edit
                if (!string.IsNullOrEmpty(currentPage)) currentPageInt = Convert.ToInt32(currentPage);
                if (string.IsNullOrEmpty(sort)) sort = "";


                #endregion

                #region genres

                var genres = busTblCategory.GetAllGenres().ToList();
                ddlGenres.InnerHtml = genres.Aggregate<tblCategory, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option {(genreIdList.Contains(itemContent.Id) ? activedropDown : "")} id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                #region ages

                var ages = busTblEsra.GetAllAges().Where(q => q.IdHead == 11 && q.Id != 7);

                ddlAges.InnerHtml = ages.Aggregate<tblEsra, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option {(ageIdList.Contains(itemContent.Id) ? activedropDown : "")} id=\"{itemContent.Id}\">{itemContent.Age}+</option>");

                #endregion

                #region platform

                var platform = busTblPlatform.GetAllPlatform().Where(x => x.Id <= 8);
                ddlGamePlatform.InnerHtml = platform.Aggregate<tblPlatform, string>(null, (current, itemContent) => current + $"<option {(platformIdList.Contains(itemContent.Id) ? activedropDown : "")} id=\"{itemContent.Id}\">{itemContent.Name}</option>");
                #endregion

                #region category
                var categories = busTblGameCategory.GetAllGameCategories();
                ddlCategory.InnerHtml = categories.Aggregate<tblGameCategory, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option {(categoryIdList.Contains(itemContent.Id) ? activedropDown : "")} id=\"{itemContent.Id}\">{itemContent.Name}</option>");

                #endregion

                long rowCount = 0;
                int pageSize = 10;
                txtSearchGameName.Text = gameName;
                if (sort == "GameName") chbSortGameName.Checked = true;
                if (sort == "LastGame") chbSortLastGame.Checked = true;
                if (sort == "GameYear") chbSortGameYear.Checked = true;
                pagination.InnerHtml = "";
                myCommon.pager pager = new myCommon.pager { Take = 10 };
                pager = myCommon.Pager(currentPageInt, pager.Take);
                bool isAndroid = searchPlatfor != null && searchPlatfor.Contains("8");
                var p = busVwIntroductionGameResults.GetAllGames_introduction(gameName, searchAge, searchPlatfor, category, searchGenre, pager, out rowCount, sort, isAndroid);

                string pattern = "<[^>]*>";
                Regex rgx = new Regex(pattern);
                if (p != null && p.Count > 0)
                {
                    foreach (vwIntroductionGameResult result in p)
                    {

                        if (result.ShowInEsraWebsite == false) { 
                            continue; }
                        string mainImg = "";
                        if (!string.IsNullOrEmpty(result.Picture))
                        {
                            string[] allImg = result.Picture.Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
                            Array.Sort(allImg);
                            if (allImg.Any())
                            {

                                mainImg = allImg[0];
                            }
                        }
                        string agesTitle = ages.SingleOrDefault(q => q.Id == result.esra_grade)?.Age;
                        string platformsTitle = result.platformID.Split(',').Aggregate("", (current, pi) => current + (platform.SingleOrDefault(q => q.Id.ToString() == pi)?.Name + ", "));
                        string continueLink = $"<a href=\"{"introGame.aspx?gi=" + result.id}\">ادامه مطلب</a>";

                        if (platformsTitle.Contains("android"))
                        {
                            continueLink = "";

                            searchResult.InnerHtml +=
                                $"<div class=\"search-result-temp1\"><a \">" +
                                    $"<img data-tilt src=\"/uploads/picture/game/icons/{result.id}/{result.Picture + "?d=" + DateTime.Now.Millisecond.ToString()}\" alt=\"\" class=\"img-search-result \" /></a>" +
                                    $"<div class=\"result-game-info\" style=\"margin-top:25px\"><div class=\"game-info\">" +
                                        $"</br></br><p>نام بازی</p><p class=\"_{agesTitle}RateC\"><a \">{result.name}</a></p>" +
                                        $"<p>پلتفرم</p><p>{platformsTitle.RemoveLastChar(",").Replace(",", "،")}</p>" +
                                        $"<p>سال</p><p>{result.publish_date.Year}</p>" +
                                        $"<p>ناشر</p><p>{result.publisher}</p></div>";
                            //                       $"<div class=\"game-type\">" +
                            //                            $"<span style=\"margin: 0 auto;display: block;position: initial;width: 39px;height: 66px;\" alt=\"\" class=\"img-search-result-rate _{agesTitle}RateB\"></span>";

                            shorterString = rgx.Replace(result.intro_short, "").WordCountToShow(550, false) + continueLink;
                            shorterString = shorterString.Remove(shorterString.Length - 3);
                            //searchResult.InnerHtml += $"</div>" +

                            searchResult.InnerHtml += $"</div>" +

                                    $"<div class=\"result-game-describe2\"  style=\"width:370px;\"><p class=\"game-describe\"  style=\"padding-right:  10px;\">{shorterString}</p></div>" +
                                    $"<div class=\"result-game-describe2\" style=\"width:50px;\"><span style=\"margin-top: 30px;display: block;position: initial;width: 78px;height:120px;\" alt=\"\" class=\"img-search-result-rate _{agesTitle}RateB\"></span></div>" +
                                    $"</div>";
                            //$"<div class=\"result-game-describe\"><p class=\"game-describe\">{shorterString}</p></div></div>";
                        }
                        else
                        {

                            //all
                            shorterString = rgx.Replace(result.intro_gameplay, "").WordCountToShow(65, false);
                            shorterString = shorterString.Remove(shorterString.Length - 3);
                            searchResult.InnerHtml +=
                                $"<div class=\"search-result-temp1\">" +
                                    $"<a href=\"{"introGame.aspx?gi=" + result.id}\">" +
                                        $"<div class=\"img-search-result\">" +
                                            $"<span data-tilt alt=\"\" class=\"img-search-result-rate _{agesTitle}RateB\"></span>" +
                                            $"<img data-tilt style=\"position:absolute;\" src=\"/uploads/picture/game/gamePic/{result.id}/{result.PictureCover + "?d=" + DateTime.Now.Millisecond.ToString()}\" alt=\"\" class=\"img-search-result \" />" +
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
                                                        $"<p class=\"game-describe\">{shorterString + continueLink}</p>" +
                                                        $"</div>" +
                                                        $"</div>";

                        }
                    }
                }
                #region pagination

                myCommon.initPager initPager = myCommon.InitPager(currentPageInt, pageSize, rowCount, pager.Take);
                string activePageCss = "class=\"active\"";
                if (initPager.NeedFirst)
                {
                    pagination.InnerHtml += $"<a href=\"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp=1&s={sort}\">صفحه اول</a>";

                    pagination.InnerHtml += $"<a href=\"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp={initPager.StartPage - 1}&s={sort}\">قبلی</a>";
                }
                for (int i = initPager.StartPage; i <= initPager.EndPage; i++)
                    pagination.InnerHtml +=
                        $"<a href=\"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp={i}&s={sort}\" {(!string.IsNullOrEmpty(currentPage) ? (i.ToString() == currentPage ? activePageCss : "") : (i == 1 ? activePageCss : ""))}>{i}</a>";
                if (initPager.NeedEnd)
                {
                    pagination.InnerHtml += $"<a href=\"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp={initPager.EndPage + 1}&s={sort}\">بعدی</a>";
                    pagination.InnerHtml += $"<a href=\"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp={initPager.LastPage}&s={sort}\">صفحه آخر</a>";
                }

                #endregion
                if (!p.Where(q => q.ShowInEsraWebsite != false).Any())
                {
                    searchResult.Attributes.CssStyle.Add("text-align", "center");
                    searchResult.Attributes.CssStyle.Add("color", "red");
                    searchResult.InnerHtml = "نتیجه برای جستجوی انجام شده پیدا نشد.";
                    pagination.InnerHtml = "";
                }
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            string sort = "LastGame";
            if (chbSortGameName.Checked) sort = "GameName";
            if (chbSortLastGame.Checked) sort = "LastGame";
            if (chbSortGameYear.Checked) sort = "GameYear";


            var gameName = txtSearchGameName.Text;
            var hfSearchGenre = hfSearchGenres.Value.RemoveLastChar(",");
            var hfSearchAge = hfSearchAges.Value.RemoveLastChar(",");
            var hfSearchPlatfor = hfSearchPlatform.Value.RemoveLastChar(",");
            var hfSearchCategory = hfSearchCategories.Value.RemoveLastChar(",");

            if (hfSearchGenre == "0") hfSearchGenre = "";
            if (hfSearchAge == "0") hfSearchAge = "";
            if (hfSearchPlatfor == "0") hfSearchPlatfor = "";
            if (hfSearchCategory == "0") hfSearchCategory = "";

            Response.Redirect(
                $"introGameResults.aspx?gn={gameName}&g={hfSearchGenre}&a={hfSearchAge}&pf={hfSearchPlatfor}&c={hfSearchCategory}&cp=1&s={sort}",
                false);
        }

        protected void btnSort_OnClick(object sender, EventArgs e)
        {
            string sort = "";
            if (chbSortGameName.Checked) sort = "GameName";
            if (chbSortLastGame.Checked) sort = "LastGame";
            if (chbSortGameYear.Checked) sort = "GameYear";


            string gameName = Request.QueryString["gn"];
            string searchGenre = Request.QueryString["g"];
            string searchAge = Request.QueryString["a"];
            string searchPlatfor = Request.QueryString["pf"];
            string currentPage = Request.QueryString["cp"];
            string category = Request.QueryString["c"];


            Response.Redirect(
                $"introGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&c={category}&cp={currentPage}&s={sort}",
                false);
        }
    }
}