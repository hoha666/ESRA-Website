using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalTbl_News
    {
        public static int InsertOneNews(Tbl_New news)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Tbl_New news1 = new Tbl_New
                {
                    Title = news.Title,
                    Intro = news.Intro,
                    Content = news.Content,
                    Auther = news.Auther,
                    Created = news.Created,
                    Picture = news.Picture,
                    Tag = news.Tag,
                    IsEdited = news.IsEdited,
                    IsDeleted = news.IsDeleted,
                    IsArchived = news.IsArchived,
                    EditedNewsID = news.EditedNewsID,
                    NewsCategoryID = news.NewsCategoryID,
                    Link = news.Link
                };
                db.Tbl_News.InsertOnSubmit(news1);
                db.SubmitChanges();
                return news1.ID;
            }
        }

        public static List<Tbl_New> GetAllNews(int id, myCommon.pager pager, out long rowCount, bool needCount)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                rowCount = 0;
                var query = (from p in db.Tbl_News select p );
                query = query.OrderByDescending(q => q.ID);
                if (id > 0) query = query.Where(p => p.ID == id);
                if (needCount) rowCount = query.Count();
                if (pager != null) query = query.Skip(pager.Skip).Take(pager.Take);
                

                return query.ToList();
            }
        }

        public static bool UpdateOneNews(Tbl_New news, int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_News
                             where (p.ID == id)
                             select p).SingleOrDefault();
                if (query != null)
                {
                    query.Title = news.Title;
                    query.Intro = news.Intro;
                    query.Content = news.Content;
                    query.Auther = news.Auther;
                    query.Created = news.Created;
                    //                    query.Picture = news.Picture;
                    query.Tag = news.Tag;
                    query.IsEdited = news.IsEdited;
                    query.IsDeleted = news.IsDeleted;
                    query.IsArchived = news.IsArchived;
                    query.EditedNewsID = news.EditedNewsID;
                    query.NewsCategoryID = news.NewsCategoryID;
                    query.Link = news.Link;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool DeleteOneNews(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_News
                             where (p.ID == id)
                             select p).SingleOrDefault();

                if (query != null)
                {

                    db.Tbl_News.DeleteOnSubmit(query);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}