using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.BUSINESSBpms
{
    public static class busTblVersionScreenshot
    {
        public static List<tblVersionScreenshot> GetAlltblVersionScreenshot()
        {
            return DalBpms.dalTblVersionScreenshot.GetAlltblVersionScreenshot();
        }
        public static List<tblVersionScreenshot> GetAlltblVersionScreenshotByIdVersion(int idVersion)
        {
            return DalBpms.dalTblVersionScreenshot.GetAlltblVersionScreenshotByIdVersion(idVersion);

        }
        public static bool InsertOnetblVersionScreenshot(tblVersionScreenshot versionScreenshot)
        {
            return DalBpms.dalTblVersionScreenshot.InsertOnetblVersionScreenshot(versionScreenshot);
        }
        public static bool UpdateOnetblVersionScreenshot(int idVersion, int idFile)
        {
            return DalBpms.dalTblVersionScreenshot.UpdateOnetblVersionScreenshot(idVersion, idFile);
        }
        public static bool DeleteOnetblVersionScreenshot(int idVersion, int idFile)
        {
            return DalBpms.dalTblVersionScreenshot.DeleteOnetblVersionScreenshot(idVersion, idFile);
        }
    }
}
