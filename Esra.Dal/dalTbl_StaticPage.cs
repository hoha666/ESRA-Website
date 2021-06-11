using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalTbl_StaticPage
    {
        public static int addNewPage(Tbl_StaticPage staticPage)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Tbl_StaticPage page = new Tbl_StaticPage
                {
                    Auther = staticPage.Auther,
                    Content = staticPage.Content,
                    Date = staticPage.Date,
                    MasterID = staticPage.MasterID,
                    Title = staticPage.Title,
                    CategoryID = staticPage.CategoryID
                };
                db.Tbl_StaticPages.InsertOnSubmit(page);
                db.SubmitChanges();
                return page.ID;
            }
        }

        public static Tbl_StaticPage getPage(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_StaticPages
                    where p.ID == id
                    select p
                    ).SingleOrDefault();
                return query;
            }
        }
        public static Tbl_StaticPage getPage(string title)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_StaticPages
                             where p.Title.Replace(" ","_") == title
                             select p
                    ).SingleOrDefault();
                return query;
            }
        }
        public static List<Tbl_StaticPage> getAllPage(out long rowCount)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_StaticPages
                    select p);
                rowCount = query.Count();
                return query.ToList();
            }
        }

        public static bool UpdateOneStaticPage(int id, Tbl_StaticPage staticPage)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_StaticPages
                    where (p.ID == id)
                    select p).SingleOrDefault();
                if (query != null)
                {
                    query.Title = staticPage.Title;
                    query.Auther = staticPage.Auther;
                    query.MasterID = staticPage.MasterID;
                    query.CategoryID = staticPage.CategoryID;
                    query.Content = staticPage.Content;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool DeleteOneStaticPages(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_StaticPages
                             where p.ID == id
                             select p).SingleOrDefault();
                if (query != null && query.ID != 0)
                {
                    db.Tbl_StaticPages.DeleteOnSubmit(query);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

    }
}