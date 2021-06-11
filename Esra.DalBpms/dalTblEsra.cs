using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public class dalTblEsra
    {
        public static List<tblEsra> GetAllAges()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblEsras
                            select p).ToList();
                return data;
            }
        }
    }
}
