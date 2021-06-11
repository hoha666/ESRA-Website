using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public static class dalTblGame
    {
        public static tblGame GetOneTblGameById(int id)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblGames where p.Id == id select p).Single();
                return data;
            }
        }
        public static bool UpdateOneTblGameById(int id,tblGame game)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    tblGame data = new tblGame();
                    if (id != 0) data = (from p in db.tblGames where p.Id == id select p).Single();
                    data.ShowInEsraWebsite = game.ShowInEsraWebsite;
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
