using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;


namespace Esra.Dal
{
    public class dalPlatforms
    {
        public static List<platform> GetAllPlatform()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                List<platform> data = (from p in db.platforms
                    select p).ToList();
                return data;
            }
        }
    }
}