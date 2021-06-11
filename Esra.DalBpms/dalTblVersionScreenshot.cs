using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public static class dalTblVersionScreenshot
    {
        public static List<tblVersionScreenshot> GetAlltblVersionScreenshot()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblVersionScreenshots select p).ToList();
                return data;
            }
        }
        public static List<tblVersionScreenshot> GetAlltblVersionScreenshotByIdVersion(int idVersion)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblVersionScreenshots where p.IdVersion== idVersion select p).ToList();
                return data;
            }
        }

        public static bool InsertOnetblVersionScreenshot(tblVersionScreenshot versionScreenshot)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    db.tblVersionScreenshots.InsertOnSubmit(versionScreenshot);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static bool UpdateOnetblVersionScreenshot(int idVersion, int idFile)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    var datas = (from p in db.tblVersionScreenshots where p.IdVersion == idVersion select p).ToList();
                    var data = (from p in db.tblVersionScreenshots where p.IdVersion == idVersion && p.IdFile == idFile select p).Single();
                    if (datas.Any())
                        foreach (tblVersionScreenshot screenshot in datas)
                            screenshot.IdScreenshotType = 2;
                    db.SubmitChanges();

                    if (data != null)
                        data.IdScreenshotType = 3;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool DeleteOnetblVersionScreenshot(int idVersion, int idFile)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    tblVersionScreenshot data = new tblVersionScreenshot();
                    if (idVersion != 0) data = (from p in db.tblVersionScreenshots
                                                where p.IdVersion == idVersion && p.IdFile==idFile
                                                select p).Single();

                    db.tblVersionScreenshots.DeleteOnSubmit(data);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
