using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGame_version_contents
    {
        public static int InsertOneGame_version_contents(game_version_content gameVersionsContent)

        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                game_version_content gvc = new game_version_content
                {
                    content_id = gameVersionsContent.content_id,
                    game_version_id = gameVersionsContent.game_version_id
                };
                db.game_version_contents.InsertOnSubmit(gvc);
                db.SubmitChanges();
                return gvc.id;
            }
        }

        public static List<game_version_content> GetListGame_version_contents(int gameVersionId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var gameVersionContent = (from p in db.game_version_contents
                                          where p.game_version_id == gameVersionId
                                          select p);
                return gameVersionContent.ToList();
            }
        }
        public static bool DeleteOneGameVersionContents(int gameVersionId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                try
                {
                    var gameVersionContent = (from p in db.game_version_contents
                        where p.game_version_id == gameVersionId
                        select p);
                    db.game_version_contents.DeleteAllOnSubmit(gameVersionContent);
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
