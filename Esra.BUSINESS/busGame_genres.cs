using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGame_genres
    {
        public static int InsertOneGame_genre(game_genre gameGenre)

        {
            return dalGame_genres.InsertOneGame_genre(gameGenre);
        }
        public static List<game_genre> GetListGame_genre(int gameId)

        {
            return dalGame_genres.GetListGame_genre(gameId);
        }
        public static bool DeleteOneGameGenres(int gameId)
        {
            return dalGame_genres.DeleteOneGameGenres(gameId);
        }
    }
}
