using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalRatingGameResults
    {
        public static List<vw_ratingGameResult> GetAllRatingGameResult(string gameName, string[] ageIdList, string[] platformIdList, string[] genreIdList, myCommon.pager pager, out long rowCount, string orderBy)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.vw_ratingGameResults select p);

                if (!string.IsNullOrEmpty(gameName))
                    query = query.Where(p => p.name.Contains(gameName));
                if (ageIdList.Any())
                    query = query.Where(p => ageIdList.Contains(p.age_id.ToString()));
                if (platformIdList.Any())
                    query = query.Where(p => platformIdList.Contains(p.platform_id.ToString()));
                if (genreIdList.Any())
                    query = query.Where(p => genreIdList.Contains(p.genre_id.ToString()));
                if (!string.IsNullOrEmpty(orderBy))
                    switch (orderBy)
                    {
                        case "GameName":
                            query = query.OrderByDescending(result => result.name);
                            break;
                        case "LastGame":
                            query = query.OrderByDescending(result => result.id);
                            break;
                        case "GameYear":
                            query = query.OrderByDescending(result => result.publish_date);
                            break;
                    }

                var query2 = query.GroupBy(t => t.name);
                var data = pager!=null ? query2.Skip(pager.Skip).Take(pager.Take).ToList() : query2.ToList();

                rowCount = query2.Count();
                var query3 = data.Select(r => new vw_ratingGameResult
                {
                    id = r.First().id,
                    name = r.First().name,
                    developer = r.First().developer,
                    publish_date = r.First().publish_date,
                    name2 = r.First().name2,
                    icon = r.First().icon,
                    esra_summary = r.First().esra_summary,


                    genres_id = string.Join(",", r.Select(q => q.genre_id).Distinct()),
                    platforms_id = string.Join(",", r.Select(q => q.platform_id).Distinct()),
                    ages_id = string.Join(",", r.Select(q => q.age_id).Distinct()),

                    platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                    genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                    agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),

                });
                return query3.ToList();
            }
        }
        public static List<vw_ratingGameResult> GetAllRatingGameResultForAdmin()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.vw_ratingGameResults select p);

                var query2 = query.ToList();
                var data = query2.GroupBy(t => t.name);

                var query3 = data.Select(r => new vw_ratingGameResult
                {
                    id = r.First().id,
                    name = r.First().name,
                    platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                    genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),

                });
                return query3.ToList();
            }
        }

    }
}