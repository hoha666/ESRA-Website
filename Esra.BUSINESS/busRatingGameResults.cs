using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busRatingGameResults
    {
        public static List<vw_ratingGameResult> GetAllRatingGameResult(string gameName, string ageId, string platformId,string genreId,myCommon.pager pager, out long rowCount, string orderBy)
        {
            string[] ageIdList = new string[] { };
            string[] platformIdList = new string[] { };
            string[] genreIdList = new string[] { };
            if (!string.IsNullOrEmpty(ageId)) ageIdList = ageId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(platformId)) platformIdList = platformId.Split(',').ToArray();
            if (!string.IsNullOrEmpty(genreId)) genreIdList = genreId.Split(',').ToArray();
            return dalRatingGameResults.GetAllRatingGameResult(gameName, ageIdList, platformIdList, genreIdList,pager,out rowCount, orderBy);
        }
        public static List<vw_ratingGameResult> GetAllRatingGameResultForAdmin()
        {
            return dalRatingGameResults.GetAllRatingGameResultForAdmin();
        }


    }
}
