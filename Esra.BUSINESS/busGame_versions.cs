using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGame_versions
    {
        public static int InsertOneGame_versions(game_version gameVersions)
        {
            return dalGame_versions.InsertOneGame_versions(gameVersions);
        }

        public static List<game_version> GetListGame_versions(int gameId)
        {
            return dalGame_versions.GetListGame_versions(gameId);
        }
        public static List<int> DeleteOneGameVersions(int gameId)
        {
            return dalGame_versions.DeleteOneGameVersions(gameId);
        }
    }
}
