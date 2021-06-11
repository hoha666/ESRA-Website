using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGame_versions
    {
        public static int InsertOneGame_versions(game_version gameVersions)

        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                game_version gv = new game_version
                {
                    age_id = gameVersions.age_id,
                    game_id = gameVersions.game_id,
                    haveproblem = gameVersions.haveproblem,
                    is_source_available = gameVersions.is_source_available,
                    platform_id = gameVersions.platform_id,
                    problem = gameVersions.problem,
                    quality = gameVersions.quality,
                    result_id = gameVersions.result_id,
                    source_id = gameVersions.source_id,


                };
                db.game_versions.InsertOnSubmit(gv);
                db.SubmitChanges();
                return gv.id;
            }
        }

        public static List<game_version> GetListGame_versions(int gameId)
        {
            using (DataClassesDataContext db= new DataClassesDataContext())
            {
                var queru = (from p in db.game_versions
                    where p.game_id == gameId
                    select p);
                return queru.ToList();
            }
        }
        public static List<int> DeleteOneGameVersions(int gameId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                try
                {
                    var queru = (from p in db.game_versions
                        where p.game_id == gameId
                        select p);
                    var s = queru.Select(p => p.id).ToList();
                    db.game_versions.DeleteAllOnSubmit(queru);
                    db.SubmitChanges();
                    return s;
                }
                catch (Exception e)
                {
                    return new List<int>();
                }
            }
        }
    }
}
