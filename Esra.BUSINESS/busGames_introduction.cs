using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busGames_introduction
    {
        public static List<games_introduction> GetAllGames_introduction(myCommon.pager pager, out long rowCount)
        {
            return dalGames_introduction.GetAllGames_introduction(pager, out rowCount, null, null);
        }


        public static List<games_introduction> GetOneGames_introduction(string id, string name)
        {
            myCommon.pager pager = new myCommon.pager { Take = 1, Skip = 0 };
            long rowCount = 0;
            if (!string.IsNullOrEmpty(id))
                return dalGames_introduction.GetAllGames_introduction(pager, out rowCount, id, "");
            if (!string.IsNullOrEmpty(name))
                return dalGames_introduction.GetAllGames_introduction(pager, out rowCount, null, name);
            else return null;
        }

        public static int InsertOneGames_introduction(games_introduction gamesIntroduction)
        {
            return dalGames_introduction.InsertOneGames_introduction(gamesIntroduction);
        }

        public static bool DeleteOneGames_introduction(int id, out string imgList)
        {
            return dalGames_introduction.DeleteOneGames_introduction(id, out imgList);
        }

        public static bool UpdateOneGames_introduction(int id, games_introduction gamesIntroduction)

        {
            return dalGames_introduction.UpdateOneGames_introduction(id, gamesIntroduction);
        }
        public static List<games_introduction> GetAllGames_introduction(string gameName, string ageId, string platformId, string category, string genreId, myCommon.pager pager, out long rowCount, string orderBy)
        {
            string[] ageIdList = new string[] { };
            string[] platformIdList = new string[] { };
            string[] genreIdList = new string[] { };
            string[] categoryIdList = new string[] { };////is new and need to edit
            if (!string.IsNullOrEmpty(ageId)) ageIdList = ageId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(platformId)) platformIdList = platformId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(genreId)) genreIdList = genreId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(category)) categoryIdList = category.Split(',').ToArray();
            return dalGames_introduction.GetAllGames_introduction(gameName, ageIdList, platformIdList, genreIdList, categoryIdList, pager, out rowCount, orderBy);
        }

        public static List<games_introduction> GetRelatedGames_introduction(string id)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(id))
                Id = Convert.ToInt32(id);
            if (Id > 0)
                return dalGames_introduction.GetRelatedGames_introduction(Id);
            else return null;
        }

        public static List<games_introduction> GetRelatedGames_introductionByAge(int age)
        {
            return dalGames_introduction.GetRelatedGames_introductionByAge(age);

        }
    }
}