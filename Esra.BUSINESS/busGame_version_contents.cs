using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGame_version_contents
    {
        public static int InsertOneGame_version_contents(game_version_content gameVersionContent)
        {
            return dalGame_version_contents.InsertOneGame_version_contents(gameVersionContent);
        }
        public static List<game_version_content> GetListGame_version_contents(int gameVersionId)
        {
            return dalGame_version_contents.GetListGame_version_contents(gameVersionId);
        }
        public static bool DeleteOneGameVersionContents(int gameVersionId)
        {
            return dalGame_version_contents.DeleteOneGameVersionContents(gameVersionId);
        }

    }
}
