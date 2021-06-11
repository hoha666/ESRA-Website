using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalGame_genres
    {
        public static int InsertOneGame_genre(game_genre gameGenre)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                game_genre gg = new game_genre
                {
                    game_id = gameGenre.game_id,
                    genre_id = gameGenre.genre_id,
                    sub_id = gameGenre.sub_id
                };
                db.game_genres.InsertOnSubmit(gg);
                db.SubmitChanges();
                return gg.id;
            }
        }

        public static List<game_genre> GetListGame_genre(int gameId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = from p in db.game_genres
                    where p.game_id == gameId
                    select p;
                return query.ToList();

            }
        }
        public static bool DeleteOneGameGenres(int gameId)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                try
                {
                    var query = from p in db.game_genres
                        where p.game_id == gameId
                        select p;
                    db.game_genres.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
    }
}