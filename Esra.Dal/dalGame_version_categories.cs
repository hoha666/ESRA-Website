using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGame_version_categories
    {
        public static int InsertOneGame_version_categories(game_version_category gameVersionCategory)


        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                game_version_category gvc = new game_version_category
                {
                    game_version_id = gameVersionCategory.game_version_id,
                    category_id = gameVersionCategory.category_id
                };
                db.game_version_categories.InsertOnSubmit(gvc);
                db.SubmitChanges();
                return gvc.id;
            }
        }

        public static List<game_version_category> GetListGame_version_categories(int gameVersionId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.game_version_categories
                             where p.game_version_id == gameVersionId
                             select p);
                return query.ToList();
            }
        }
        public static bool DeleteOneGameVersionCategories(int gameVersionId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                try
                {
                    var query = (from p in db.game_version_categories
                        where p.game_version_id == gameVersionId
                        select p);
                    db.game_version_categories.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
