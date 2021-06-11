using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalUsers
    {
        public static user GetUserInfo(string userName)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var data = (from p in db.users
                    where p.username == userName
                    select p).SingleOrDefault();
                return data;
            }
        }
    }
}
