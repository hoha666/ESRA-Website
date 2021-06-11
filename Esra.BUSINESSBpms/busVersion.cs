using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.DalBpms;

namespace Esra.BUSINESSBpms
{
    public static class busVersion
    {
        public static tblVersion UpdateOneVersion(int idGame, int idPlatform, tblVersion version)

        {
            return dalVersion.UpdateOneVersion(idGame, idPlatform, version);
        }
    }
}