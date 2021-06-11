using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalAges
    {
        public static List<age> GetAllAges()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.ages
                            select p).ToList();
                return data;
            }
        }
    }
}
