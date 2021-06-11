using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalTbl_NewsCategory
    {
        public static List<Tbl_NewsCategory> GetAllNewsCategories(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_NewsCategories select p);
                if (id > 0) query = query.Where(p => p.ID == id);
                return query.ToList();
            }
        }

    }
}
