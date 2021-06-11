using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.BUSINESSBpms;
using Esra.COMMON;

namespace Esra.WebUI
{
    public partial class ratingGameResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string activedropDown = $"class=\"js-active\"";

                #region queryString proccess

                string gameName = Request.QueryString["gn"];
                string searchGenre = Request.QueryString["g"];
                string searchAge = Request.QueryString["a"];
                string searchPlatfor = Request.QueryString["pf"];
                string currentPage = Request.QueryString["cp"];
                string sort = Request.QueryString["s"];

                int[] ageIdList = new int[] { };
                int[] platformIdList = new int[] { };
                int[] genreIdList = new int[] { };
                int currentPageInt = 1;
                if (!string.IsNullOrEmpty(searchAge)) ageIdList = searchAge.Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(searchPlatfor))
                    platformIdList = searchPlatfor.Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(searchGenre))
                    genreIdList = searchGenre.Split(',').Select(int.Parse).ToArray();
                if (!string.IsNullOrEmpty(currentPage)) currentPageInt = Convert.ToInt32(currentPage);
                if (string.IsNullOrEmpty(sort)) sort = "";


                #endregion

                #region genres

                var genres = busTblCategory.GetAllGenres();
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
                ddlGamePlatform.InnerHtml = platform.Aggregate<tblPlatform, string>(null,
                    (current, itemContent) =>
                        current +
                        $"<option {(platformIdList.Contains(itemContent.Id) ? activedropDown : "")} id=\"{itemContent.Id}\">{itemContent.Name}</option>");

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
                var p = busVwRatingGameResult.GetAllRatingGameResult(gameName, searchAge, searchPlatfor, searchGenre, pager, out rowCount, sort);
                searchResult.InnerHtml = $"<div class=\"search-result-temp2\" style=\"border: 0;background-color: #f7f7f7;font-size: 14px;margin-bottom: 17px;\"><div class=\"game-info2\"><p>نام بازی</p><p>سبک بازی</p><p>پلتفرم</p><p>سال نشر</p><p>ناشرین مجاز</p></div></div>";///*<p>ناشر خارجی</p>*/

                foreach (vwRatingGameResults_ result in p)
                {
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

                            for (int i = 0; i < dt.Rows.Count && dt != null; i++)
                            {
                                ConfirmedPublishers += dt.Rows[i][0].ToString();
                                if (i != (dt.Rows.Count - 1)) ConfirmedPublishers += " , ";
                                cpCount++;
                            }
                        }
                    }
                    if (cpCount > 0)
                    {
                        if (cpCount > 1)
                        {
                            searchResult.InnerHtml +=
                                $"<div class=\"search-result-temp2\">" +
                                    $"<span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\">" +
                                    $"</span>" +
                                        $"<div class=\"game-info2\">" +
                                            //                                    $"<p>نام بازی</p>" +
                                            $"<p class=\"_{result.agesTitle}RateC\">{result.gameName}</p>" +
                                                //                                    $"<div class=\"item\">" +
                                                //                                        $"<p>سبک بازی</p>" +
                                                //                                        $"<p>پلتفرم</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                $"<p>{result.genresTitle}</p>" +
                                                $"<p>{result.platformsTitle}</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                //                                        $"<p>سال</p>" +
                                                //                                        $"<p>شرکت سازنده</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                $"<p>{result.ReleaseDateTime.Value.Year}</p>" +
                                        //$"<p class=\"mosha\" onclick=\"myFunction({result.gameId})\" > مشاهده </p><input type=\"hidden\" value=\"{ConfirmedPublishers}\" id=\"pos{result.gameId}\"/>" +
                                        //$"<p><a href=\"#ex{result.gameId}\" rel=\"modal:open\">لیست ناشرین مجاز</a></p> <div id=\"ex{result.gameId}\" class=\"modal\"><p>{ConfirmedPublishers}</p><a href=\"#\" rel=\"modal:close\">Close</a></div>" +
                                        //$"<p class=\"mosha\" onclick=\"myFunction({result.gameId})\" > لیست ناشرین مجاز </p><div id=\"modal{result.gameId}\" class=\"w3 - modal\"><div class=\"w3 - modal - content\"><div class=\"w3 - container\"><span onclick=\"document.getElementById('modal{result.gameId}').style.display = 'none'\" class=\"w3 - button w3 - display - topright\">&times;</span> <p>{ConfirmedPublishers}</p></div></div></div> " +  
                                        $"<a class=\"btn\" href=\"#open-modal{result.gameId}\">لیست ناشرین</a> <div id=\"open-modal{result.gameId}\" class=\"modal-window\"><div style=\"direction: rtl; \"> <a  href=\"#\" title=\"Close\" class=\"modal-close\">بستن</a><hr> <div class=\"jizpalavak\" > {ConfirmedPublishers}</div></div></div>" +
                                        $"</div>" +
                                $"</div>";
                        }
                        else
                        {
                            searchResult.InnerHtml +=
                                $"<div class=\"search-result-temp2\">" +
                                    $"<span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\">" +
                                    $"</span>" +
                                        $"<div class=\"game-info2\">" +
                                            //                                    $"<p>نام بازی</p>" +
                                            $"<p class=\"_{result.agesTitle}RateC\">{result.gameName}</p>" +
                                                //                                    $"<div class=\"item\">" +
                                                //                                        $"<p>سبک بازی</p>" +
                                                //                                        $"<p>پلتفرم</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                $"<p>{result.genresTitle}</p>" +
                                                $"<p>{result.platformsTitle}</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                //                                        $"<p>سال</p>" +
                                                //                                        $"<p>شرکت سازنده</p>" +
                                                //                                    $"</div>" +
                                                //                                    $"<div class=\"item\">" +
                                                $"<p>{result.ReleaseDateTime.Value.Year}</p>" +
                                                 //$"<p>{result.OrganizationName}</p>" +
                                                 //                                        $"<p class='popup' onclick=\"myFunction({result.gameId})\">کلیک کنید <span class=\"popuptext\" id=\"myPopup{result.gameId}\" > {ConfirmedPublishers} </span> </p>" +
                                                 $"<p>{ConfirmedPublishers}</p>" +
                                        $"</div>" +
                                $"</div>";
                        }
                    }
                    else
                    {
                        searchResult.InnerHtml +=
                            $"<div class=\"search-result-temp2\">" +
                                $"<span alt=\"\" class=\"img-search-result-rate2 _{result.agesTitle}Rate\">" +
                                $"</span>" +
                                    $"<div class=\"game-info2\">" +
                                        //                                    $"<p>نام بازی</p>" +
                                        $"<p class=\"_{result.agesTitle}RateC\">{result.gameName}</p>" +
                                            //                                    $"<div class=\"item\">" +
                                            //                                        $"<p>سبک بازی</p>" +
                                            //                                        $"<p>پلتفرم</p>" +
                                            //                                    $"</div>" +
                                            //                                    $"<div class=\"item\">" +
                                            $"<p>{result.genresTitle}</p>" +
                                            $"<p>{result.platformsTitle}</p>" +
                                            //                                    $"</div>" +
                                            //                                    $"<div class=\"item\">" +
                                            //                                        $"<p>سال</p>" +
                                            //                                        $"<p>شرکت سازنده</p>" +
                                            //                                    $"</div>" +
                                            //                                    $"<div class=\"item\">" +
                                            $"<p>{result.ReleaseDateTime.Value.Year}</p>" +
                                             //$"<p>{result.OrganizationName}</p>" +
                                             //                                        $"<p class='popup' onclick=\"myFunction({result.gameId})\">کلیک کنید <span class=\"popuptext\" id=\"myPopup{result.gameId}\" > {ConfirmedPublishers} </span> </p>" +
                                             $"<p></p>" +
                                    $"</div>" +
                            $"</div>";
                    }
                }
                #region pagination

                myCommon.initPager initPager = myCommon.InitPager(currentPageInt, pageSize, rowCount, pager.Take);
                string activePageCss = "class=\"active\"";
                if (initPager.NeedFirst)
                {
                    pagination.InnerHtml += $"<a href=\"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp=1&s={sort}\">صفحه اول</a>";
                    pagination.InnerHtml += $"<a href=\"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp={initPager.StartPage - 1}&s={sort}\">قبلی</a>";
                }
                for (int i = initPager.StartPage; i <= initPager.EndPage; i++)
                    pagination.InnerHtml +=
                        $"<a href=\"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp={i}&s={sort}\" {(!string.IsNullOrEmpty(currentPage) ? (i.ToString() == currentPage ? activePageCss : "") : (i == 1 ? activePageCss : ""))}>{i}</a>";
                if (initPager.NeedEnd)
                {
                    pagination.InnerHtml += $"<a href=\"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp={initPager.EndPage + 1}&s={sort}\">بعدی</a>";
                    pagination.InnerHtml += $"<a href=\"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp={initPager.LastPage}&s={sort}\">صفحه آخر</a>";
                }

                #endregion
                if (!p.Any())
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
            string sort = "GameName";
            if (chbSortGameName.Checked) sort = "GameName";
            if (chbSortLastGame.Checked) sort = "LastGame";
            if (chbSortGameYear.Checked) sort = "GameYear";


            var gameName = txtSearchGameName.Text;
            var hfSearchGenre = hfSearchGenres.Value.RemoveLastChar(",");
            var hfSearchAge = hfSearchAges.Value.RemoveLastChar(",");
            var hfSearchPlatfor = hfSearchPlatform.Value.RemoveLastChar(",");

            if (hfSearchGenre == "0") hfSearchGenre = "";
            if (hfSearchAge == "0") hfSearchAge = "";
            if (hfSearchPlatfor == "0") hfSearchPlatfor = "";

            Response.Redirect(
                $"ratingGameResults.aspx?gn={gameName}&g={hfSearchGenre}&a={hfSearchAge}&pf={hfSearchPlatfor}&cp=1&s={sort}",
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

            Response.Redirect(
                $"ratingGameResults.aspx?gn={gameName}&g={searchGenre}&a={searchAge}&pf={searchPlatfor}&cp={currentPage}&s={sort}",
                false);
        }
    }
}