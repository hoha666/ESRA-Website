using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.DalBpms;

namespace Esra.BUSINESSBpms
{
    public class busTblPlatform
    {
        public static List<tblPlatform> GetAllPlatform()
        {
            return dalTblPlatform.GetAllPlatform();
        }
    }
}
