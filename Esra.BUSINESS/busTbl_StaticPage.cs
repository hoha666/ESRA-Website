using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busTbl_StaticPage
    {
        public static int addNewPage(Tbl_StaticPage staticPage)
        {
            return dalTbl_StaticPage.addNewPage(staticPage);
        }
        public static Tbl_StaticPage getPage(int id)
        {
            return dalTbl_StaticPage.getPage(id);
        }
        public static Tbl_StaticPage getPage(string title)
        {
            title = title.Split('-')[0];
            return dalTbl_StaticPage.getPage(title);
        }
        public static List<Tbl_StaticPage> getAllPage(out long rowCount)
        {
            return dalTbl_StaticPage.getAllPage(out rowCount);
        }
        public static bool UpdateOneStaticPage(int id, Tbl_StaticPage staticPage)
        {
            return dalTbl_StaticPage.UpdateOneStaticPage(id, staticPage);
        }
        public static bool DeleteOneStaticPages(int id)
        {
            return dalTbl_StaticPage.DeleteOneStaticPages(id);
        }
    }
}
