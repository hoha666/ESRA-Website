using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGenres
    {
        public static List<genre> GetAllGenres()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.genres
                            select p).ToList();
                return data;
            }
        }
    }
}
