using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
   public class dalSources
    {
        public static List<source> GetAllSource()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.sources
                    select p).ToList();
                return data;
            }
        }
    }
}
