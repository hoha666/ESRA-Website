using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public class dalVvwRatingGameResult
    {
        public static List<vwRatingGameResults_> GetAllRatingGameResult(string gameName, string[] ageIdList, string[] platformIdList, string[] genreIdList, myCommon.pager pager, out long rowCount, string orderBy)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                db.CommandTimeout = 60;
                var query = (from p in db.vwRatingGameResults_s select p);

                query = query.Where(p => p.agesId != 0);
                if (!string.IsNullOrEmpty(gameName))
                    query = query.Where(p => p.gameName.Contains(gameName));
                if (ageIdList.Any())
                    query = query.Where(p => ageIdList.Contains(p.agesId.ToString()));
                if (platformIdList.Any())
                    query = query.Where(p => platformIdList.Contains(p.platformId.ToString()));
                if (genreIdList.Any())
                    query = query.Where(p => genreIdList.Contains(p.genreId.ToString()));
                if (!string.IsNullOrEmpty(orderBy))
                    switch (orderBy)
                    {
                        case "GameName":
                            query = query.OrderByDescending(result => result.gameName);
                            break;
                        case "LastGame":
                            query = query.OrderByDescending(result => result.esra_time);
                            break;
                        case "GameYear":
                            query = query.OrderByDescending(result => result.ReleaseDateTime);
                            break;
                    }
                var tempq = query.ToList();
                var query2 = tempq.GroupBy(t => t.gameName);
                var data = pager != null ? query2.Skip(pager.Skip).Take(pager.Take).ToList() : query2;
                rowCount = query2.Count();
                var query3 = data.Select(r => new vwRatingGameResults_
                {
                    gameId = r.First().gameId,


                    //gameName = r.First().gameName,
                    gameName = (r.Count() > 1) ? r.First().gameName + "<br>" : r.First().gameName,
                    OrganizationName = r.First().OrganizationName,
                    ReleaseDateTime = r.First().ReleaseDateTime,
                    gameName2 = r.First().gameName2,


                    genreIdTemp = string.Join(",", r.Select(q => q.genreId).Distinct()),
                    platformIdTemp = string.Join(",", r.Select(q => q.platformId).Distinct()),
                    agesIdTemp = string.Join(",", r.Select(q => q.agesId).Distinct().Average()),

                    platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                    genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                    agesTitle = r.First().agesTitle,//string.Join(",", r.Where(q=>q.agesId == r.Select(q2 => q2.agesId).Distinct().Average()).Select(q => q.agesTitle).Distinct()),

            });
            var endResult = query3.ToList();
            return endResult;
        }
    }

}
}
