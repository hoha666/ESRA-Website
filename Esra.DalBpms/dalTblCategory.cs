using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public class dalTblCategory
    {
        public static List<tblCategory> GetAllGenres()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblCategories
                            where p.IdCategoryType == 1 && (p.Id != 20) && ( p.Id != 21 ) && (p.Id != 22)
                            select p).ToList();
                return data;
            }
        }
    }
}
