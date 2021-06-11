using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGames
    {
        public static int InsertOneGame(game game)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                game g = new game
                {
                    developer = game.developer,
                    icon = game.icon,
                    name = game.name,
                    name2 = game.name2,
                    publish_date = game.publish_date,
                    esra_summary = game.esra_summary
                };
                db.games.InsertOnSubmit(g);
                db.SubmitChanges();
                return g.id;
            }
        }

        public static game GetOneGame(int id, string name, out int count)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {

                var query = (from p in db.games select p);
                if (id != 0)
                    query = query.Where(p => p.id == id);
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(p => p.name == name);
                try
                {
                    count = query.Count();
                    return query.Single();

                }
                catch (Exception)
                {
                    count = query.Count();
                    return null;

                }
            }
        }
        public static bool DeleteOneGame(int id)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                try
                {
                    var query = (from p in db.games
                                 where p.id == id
                                 select p).Single();
                    db.games.DeleteOnSubmit(query);
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
