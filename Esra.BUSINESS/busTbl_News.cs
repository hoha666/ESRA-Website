using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busTbl_News
    {
        public static int InsertOneNews(Tbl_New news)

        {
            return dalTbl_News.InsertOneNews(news);
        }

        public static List<Tbl_New> GetAllNews(int id)

        {
            long rowCount = 0;
            return dalTbl_News.GetAllNews(id, null, out rowCount, false);
        }
        public static List<Tbl_New> GetAllNews(int id, myCommon.pager pager)
        {
            long rowCount = 0;

            return dalTbl_News.GetAllNews(id, pager, out rowCount, false);
        }
        public static List<Tbl_New> GetAllNews(int id, myCommon.pager pager, out long rowCount, bool needCount)
        {
            return dalTbl_News.GetAllNews(id, pager, out rowCount, needCount);
        }
        public static bool UpdateOneNews(Tbl_New news, int id)

        {
            return dalTbl_News.UpdateOneNews(news, id);
        }
        public static bool DeleteOneNews(int id)

        {
            return dalTbl_News.DeleteOneNews(id);
        }
    }
}
