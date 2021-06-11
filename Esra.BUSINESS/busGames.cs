using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGames
    {
        public static int InsertOneGame(game game)
        {
            return dalGames.InsertOneGame(game);
        }
        public static game GetOneGame(int id)
        {
            int count = 0;
            return dalGames.GetOneGame(id, null, out count);
        }
        public static game GetOneGame(string name, out int count)
        {
            return dalGames.GetOneGame(0, name, out count);
        }
        public static bool DeleteOneGame(int id)
        {
            return dalGames.DeleteOneGame(id);
        }
    }
}
