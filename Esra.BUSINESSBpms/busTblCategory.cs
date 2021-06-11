using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.DalBpms;

namespace Esra.BUSINESSBpms
{
    public class busTblCategory
    {
        public static List<tblCategory> GetAllGenres()
        {
            List<tblCategory> list = dalTblCategory.GetAllGenres();//.Select(x => x.Id != 20 || x.Id != 21 || x.Id != 22);
            return list;
        }
    }
}
