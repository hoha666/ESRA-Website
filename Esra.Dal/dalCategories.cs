using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalCategories
    {
        public static List<category> GetAllCategories()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.categories
                            select p).ToList();
                return data;
            }
        }
    }
}
