using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;


namespace Esra.DalBpms
{
    public static class dalVersion
    {
        public static tblVersion UpdateOneVersion(int idGame, int idPlatform, tblVersion version)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    var data = new tblVersion();
                    var allversions = (from p in db.tblVersions where p.IdGame == idGame && p.IdPlatform == idPlatform select p);
                    foreach( var t in allversions)
                    {
                        if(t.IsEdited == true)
                        {
                            var allversions2 = (from p in db.tblVersions where p.IdGame == idGame && p.IdPlatform == idPlatform && p.IsEdited == true select p).OrderByDescending(p => p.Id).FirstOrDefault();
                            data = allversions2;
                        }
                        else
                        {
                            data = (from p in db.tblVersions where p.IdGame == idGame && p.IdPlatform == idPlatform  select p).OrderByDescending(p=>p.Id).FirstOrDefault();
                        }
                    }
                    
                    data.IntroductionMin = version.IntroductionMin;
                    data.GamePlay = version.GamePlay;
                    data.ParentRecommendation = version.ParentRecommendation;
                    db.SubmitChanges();
                    return data;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
