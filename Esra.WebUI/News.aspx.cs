using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;

namespace Esra.WebUI
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string newsId = Request.QueryString["nid"];
            int newsIdInt = 0;
            if (!string.IsNullOrEmpty(newsId)) newsIdInt = Convert.ToInt32(newsId);

            #region show single GameIntro

            long singleRowCount = 0;
            var singleNews = new Tbl_New();
            if (newsIdInt > 0)
                singleNews =
                    busTbl_News.GetAllNews(newsIdInt, new myCommon.pager { Take = 1 }, out singleRowCount, false)
                        .SingleOrDefault();
            if (singleNews != null && singleNews.ID != 0)
            {
                string pic = "";
                if (singleNews.Picture.Split(',').ToArray().Skip(1).Any())
                    pic = singleNews.Picture.Split(',')
                        .ToArray()
                        .Skip(1)
                        .Aggregate(pic,
                            (current, s) => current + $"<img src=\"/IMG/News/{s.RemoveLastChar(",")}\" alt=\"\" />");
                //                newsRow.InnerHtml = $"<h1>{singleNews.Title}</h1><h4>| {singleNews.Auther} | {singleNews.Created}</h4><h2>{singleNews.Intro}</h2><article><img src=\"/IMG/News/{singleNews.Picture}\" alt=\"\" />{singleNews.Content}</article><div class=\"newsImageList\"><img src=\"\" alt=\"\" /><img src=\"\" alt=\"\" /><img src=\"\" alt=\"\" /></div>";
                newsRow.InnerHtml =
                    $"<article><img src=\"/IMG/News/{singleNews.Picture}\" alt=\"\" /><h1>{singleNews.Title}</h1><h4>| {singleNews.Auther} | {singleNews.Created}</h4><h2>{singleNews.Intro}</h2>{singleNews.Content}</article><div class=\"newsImageList\">{pic}</div>";
                //                pnlAllNews.Visible = false;
            }
            else
            {
                newsRow.Visible = false;
            }

            #endregion

            #region GetRandom last 10 GameIntro

            var takeNews = 10;
            if (singleNews != null && singleNews.ID != 0)
                takeNews = 3;

            long rowCount = 0;
            var news = busTbl_News.GetAllNews(0, new myCommon.pager { Take = takeNews }, out rowCount, true);
            foreach (Tbl_New tblNew in news)
            {
                secLast3GameNews.InnerHtml +=
                    $"<div class=\"divNews ffffff\"><div data-tilt class=\"DivNewsImg\" style=\"background: url(IMG/News/{tblNew.Picture}) no-repeat\"><div class=\"DivTag2\"></div><div class=\"DivTag\"><p>اخبار</p></div></div><p class=\"NewsTitle\">{tblNew.Title}</p><p class=\"NewsSubTitle\">{tblNew.Intro}</p><a href=\"/news.aspx?nid={tblNew.ID}\">{tblNew.Link}</a></div>";
            }

            if (singleNews == null || singleNews.ID == 0)

            {
                #region pagination

                string currentPage = Request.QueryString["cp"];
                int pageSize = takeNews;
                int currentPageInt = 1;
                if (!string.IsNullOrEmpty(currentPage)) currentPageInt = Convert.ToInt32(currentPage);
                myCommon.pager pager = new myCommon.pager { Take = takeNews };
                pager = myCommon.Pager(currentPageInt, pager.Take);

                myCommon.initPager initPager = myCommon.InitPager(currentPageInt, pageSize, rowCount, pager.Take);
                string activePageCss = "class=\"active\"";
                if (initPager.NeedFirst)
                    pagination.InnerHtml +=
                        $"<a href=\"news.aspx?cp={initPager.StartPage - 1}\">قبلی</a>";
                for (int i = initPager.StartPage; i <= initPager.EndPage; i++)
                    pagination.InnerHtml +=
                        $"<a href=\"news.aspx?cp={i}\" {(!string.IsNullOrEmpty(currentPage) ? (i.ToString() == currentPage ? activePageCss : "") : (i == 1 ? activePageCss : ""))}>{i}</a>";
                if (initPager.NeedEnd)
                    pagination.InnerHtml +=
                        $"<a href=\"news.aspx?cp={initPager.EndPage + 1}\">بعدی</a>";

                #endregion 
            }

            #endregion
        }
    }
}