using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public class dalTblGameCategory
    {
        public static List<tblGameCategory> GetAllGameCategories()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblGameCategories select p).ToList();
                return data;
            }
        }
    }
}
