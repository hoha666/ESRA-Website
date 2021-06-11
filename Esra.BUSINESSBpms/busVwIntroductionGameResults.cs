using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.DalBpms;

namespace Esra.BUSINESSBpms
{
    public class busVwIntroductionGameResults
    {
        public static List<vwIntroductionGameResult> GetAllGames_introduction(myCommon.pager pager, out long rowCount , string reqType = "total")
        {
            return dalVwIntroductionGameResults.GetAllGames_introduction(pager, out rowCount, null, null,reqType);
        }
        public static List<vwIntroductionGameResult> GetOneGames_introduction(string id, string name)
        {
            myCommon.pager pager = new myCommon.pager { Take = 1, Skip = 0 };
            long rowCount = 0;
            if (!string.IsNullOrEmpty(id))
                return dalVwIntroductionGameResults.GetAllGames_introduction(pager, out rowCount, id, "");
            if (!string.IsNullOrEmpty(name))
                return dalVwIntroductionGameResults.GetAllGames_introduction(pager, out rowCount, null, name);
            else return null;
        }
        public static List<vwIntroductionGameResult> GetAllGames_introduction(string gameName, string ageId, string platformId, string category, string genreId, myCommon.pager pager, out long rowCount, string orderBy,bool isAndroid)
        {
            string[] ageIdList = new string[] { };
            string[] platformIdList = new string[] { };
            string[] genreIdList = new string[] { };
            string[] categoryIdList = new string[] { };////is new and need to edit
            if (!string.IsNullOrEmpty(ageId)) ageIdList = ageId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(platformId)) platformIdList = platformId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(genreId)) genreIdList = genreId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(category)) categoryIdList = category.Split(',').ToArray();
            return dalVwIntroductionGameResults.GetAllGames_introduction(gameName, ageIdList, platformIdList, genreIdList, categoryIdList, pager, out rowCount, orderBy, isAndroid);
        }
        public static List<vwIntroductionGameResult> GetRelatedGames_introduction(string id)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(id))
                Id = Convert.ToInt32(id);
            if (Id > 0)
                return dalVwIntroductionGameResults.GetRelatedGames_introduction(Id);
            else return null;
        }

        public static List<vwIntroductionGameResult> GetRelatedGames_introductionByAge(int age)
        {
            return dalVwIntroductionGameResults.GetRelatedGames_introductionByAge(age);

        }
    }
}
