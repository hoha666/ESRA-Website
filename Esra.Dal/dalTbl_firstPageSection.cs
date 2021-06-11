using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalTbl_firstPageSection
    {
        public static int InsertOneFirstPageSection(Tbl_FirstPageSection pageSection)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Tbl_FirstPageSection fps = new Tbl_FirstPageSection
                {
                    ContinueLink = pageSection.ContinueLink,
                    Descrip = pageSection.Descrip,
                    ImgUrl = pageSection.ImgUrl,
                    Title = pageSection.Title,
                    Title2 = pageSection.Title2
                };
                db.Tbl_FirstPageSections.InsertOnSubmit(fps);
                db.SubmitChanges();
                return fps.ID;
            }
        }
        public static List<Tbl_FirstPageSection> GetAllFirstPageSection(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_FirstPageSections select p);
                if (id > 0) query = query.Where(p => p.ID == id);
                return query.ToList();
            }
        }
        public static bool UpdateOneFirstPageSection(Tbl_FirstPageSection pageSection, int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_FirstPageSections
                             where (p.ID == id)
                             select p).SingleOrDefault();

                if (query != null)
                {
                    query.ContinueLink = pageSection.ContinueLink;
                    query.Descrip = pageSection.Descrip;
                    query.Title = pageSection.Title;
                    query.Title2 = pageSection.Title2;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool DeleteOneFirstPageSection(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_FirstPageSections
                             where (p.ID == id)
                             select p).SingleOrDefault();

                if (query != null)
                {
                    db.Tbl_FirstPageSections.DeleteOnSubmit(query);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

    }
}
