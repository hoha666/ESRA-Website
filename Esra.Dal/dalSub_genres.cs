using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
   public class dalSub_genres
    {
        public static List<sub_genre> GetAllSubGenres()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.sub_genres
                            select p).ToList();
                return data;
            }
        }
    }
}
