using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalContents
    {
        public static List<content> GetAllContents()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.contents
                            select p).ToList();
                return data;
            }
        }
    }
}
