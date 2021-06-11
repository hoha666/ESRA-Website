using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Mono.Linq.Expressions;

namespace Esra.Dal
{
    public class dalGames_introduction
    {
        public static List<games_introduction> GetAllGames_introduction(myCommon.pager pager, out long rowCount, string id, string name)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.games_introductions select p);
                if (!string.IsNullOrEmpty(id))
                    query = query.Where(p => p.id.ToString() == id);
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(p => p.name.ToString() == name);
                rowCount = query.Count();
                if (pager != null)
                    query = query.Skip(pager.Skip).Take(pager.Take);
                return query.ToList();
            }
        }

        public static List<games_introduction> GetAllGames_introduction(string gameName, string[] ageIdList, string[] platformIdList, string[] genreIdList, string[] categoryIdList, myCommon.pager pager, out long rowCount, string orderBy)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.games_introductions select p);

                var predicateP = PredicateBuilder.False<games_introduction>();
                var predicateG = PredicateBuilder.False<games_introduction>();
                var predicateC = PredicateBuilder.False<games_introduction>();////is new and need to edit

                if (!string.IsNullOrEmpty(gameName))
                    query = query.Where(p => p.name.Contains(gameName));

                if (ageIdList.Any())
                    query = query.Where(p => ageIdList.Contains(p.esra_grade.ToString()));

                if (platformIdList.Any())
                {
                    predicateP = platformIdList.Aggregate(predicateP,
                        (current, s) => current.OrElse(p => p.platformID.Contains(s)));
                    query = query.Where(predicateP);
                }

                if (genreIdList.Any())
                {
                    predicateG = genreIdList.Aggregate(predicateG,
                        (current, s) => current.OrElse(p => p.genreID.Contains(s)));
                    query = query.Where(predicateG);
                }

                if (categoryIdList.Any())////is new and need to edit
                {
                    predicateC = categoryIdList.Aggregate(predicateC,
                        (current, s) => current.OrElse(p => p.categories.Contains(s)));
                    query = query.Where(predicateC);
                }

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
                rowCount = query.Count();
                return query.Skip(pager.Skip).Take(pager.Take).ToList();
            }
        }

        public static int InsertOneGames_introduction(games_introduction gamesIntroduction)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                games_introduction gi = new games_introduction
                {
                    name = gamesIntroduction.name,
                    publisher = gamesIntroduction.publisher,
                    genreID = gamesIntroduction.genreID,
                    platformID = gamesIntroduction.platformID,
                    source_id = gamesIntroduction.source_id,
                    publish_date = gamesIntroduction.publish_date,
                    intro_short = gamesIntroduction.intro_short,
                    intro_intro = gamesIntroduction.intro_intro,
                    intro_gameplay = gamesIntroduction.intro_gameplay,
                    reviewers_score = gamesIntroduction.reviewers_score,
                    esra_grade = gamesIntroduction.esra_grade,
                    esra_skill = gamesIntroduction.esra_skill,
                    esra_violence = gamesIntroduction.esra_violence,
                    esra_fear = gamesIntroduction.esra_fear,
                    esra_drugs = gamesIntroduction.esra_drugs,
                    esra_anomalies = gamesIntroduction.esra_anomalies,
                    esra_despair = gamesIntroduction.esra_despair,
                    Picture = gamesIntroduction.Picture,
                    categories = gamesIntroduction.categories
                };
                db.games_introductions.InsertOnSubmit(gi);
                db.SubmitChanges();
                return gi.id;
            }
        }

        public static bool DeleteOneGames_introduction(int id, out string imgList)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                imgList = "";
                var query = (from p in db.games_introductions
                             where p.id == id
                             select p).SingleOrDefault();
                if (query != null && query.id != 0)
                {
                    imgList = query.Picture;
                    db.games_introductions.DeleteOnSubmit(query);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool UpdateOneGames_introduction(int id, games_introduction gamesIntroduction)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.games_introductions
                             where (p.id == id)
                             select p).SingleOrDefault();
                if (query != null)
                {
                    query.name = gamesIntroduction.name;
                    query.publisher = gamesIntroduction.publisher;
                    query.genreID = gamesIntroduction.genreID;
                    query.platformID = gamesIntroduction.platformID;
                    query.source_id = gamesIntroduction.source_id;
                    query.publish_date = gamesIntroduction.publish_date;
                    query.intro_short = gamesIntroduction.intro_short;
                    query.intro_intro = gamesIntroduction.intro_intro;
                    query.intro_gameplay = gamesIntroduction.intro_gameplay;
                    query.reviewers_score = gamesIntroduction.reviewers_score;
                    query.esra_grade = gamesIntroduction.esra_grade;
                    query.esra_skill = gamesIntroduction.esra_skill;
                    query.esra_violence = gamesIntroduction.esra_violence;
                    query.esra_fear = gamesIntroduction.esra_fear;
                    query.esra_drugs = gamesIntroduction.esra_drugs;
                    query.esra_anomalies = gamesIntroduction.esra_anomalies;
                    query.esra_despair = gamesIntroduction.esra_despair;
                    query.Picture = gamesIntroduction.Picture;

                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public static List<games_introduction> GetRelatedGames_introduction(int id)
        {
            if (id > 0)
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    var query = (from p in db.games_introductions
                                 where p.id == id
                                 select p).SingleOrDefault();
                    if (query != null && query.id > 0)
                    {
                        var reQuery = (from p in db.games_introductions
                                       where
                                           (p.platformID.Contains(query.platformID)  &&
                                           p.esra_grade == query.esra_grade &&
                                           p.genreID == query.genreID) &&
                                           (p.id != id)
                                       select p).Take(2);
                        return reQuery.ToList();
                    }
                    return null;
                }
            else return null;
        }

        public static List<games_introduction> GetRelatedGames_introductionByAge(int age)
        {
            if (age > 0)
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    var query = (from p in db.games_introductions
                                 where p.esra_grade == age
                                 select p).Take(2);
                    if (query.Any())
                    {
                        return query.ToList();
                    }
                    return null;
                }
            else return null;
        }
    }
}