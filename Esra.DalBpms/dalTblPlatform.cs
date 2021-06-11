using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public class dalTblPlatform
    {
        public static List<tblPlatform> GetAllPlatform()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                List<tblPlatform> data = (from p in db.tblPlatforms
                                          select p).ToList();
                return data;
            }
        }
    }
}
