using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGame_version_categories
    {
        public static int InsertOneGame_version_categories(game_version_category gameVersionCategory)
        {
            return dalGame_version_categories.InsertOneGame_version_categories(gameVersionCategory);
        }
        public static List<game_version_category> GetListGame_version_categories(int versionCategoriesId)
        {
            return dalGame_version_categories.GetListGame_version_categories(versionCategoriesId);
        }
        public static bool DeleteOneGameVersionCategories(int gameVersionId)
        {
            return dalGame_version_categories.DeleteOneGameVersionCategories(gameVersionId);
        }
    }
}
