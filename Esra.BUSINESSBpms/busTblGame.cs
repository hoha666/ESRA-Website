using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.DalBpms;

namespace Esra.BUSINESSBpms
{
    public static class busTblGame
    {
        public static tblGame GetOneTblGameById(int id)
        {
            return dalTblGame.GetOneTblGameById(id);
        }
        public static bool UpdateOneTblGameById(int id, tblGame game)
        {
            return dalTblGame.UpdateOneTblGameById(id,game);
        }
    }

}
