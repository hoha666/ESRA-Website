using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Mono.Linq.Expressions;


namespace Esra.DalBpms
{
    public class dalVwIntroductionGameResults
    {
        private static List<IGrouping<string, vwIntroductionGameResult>> data;

        public static List<vwIntroductionGameResult> GetAllGames_introduction(myCommon.pager pager, out long rowCount, string id, string name, string reqType = "total")
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                if (reqType == "total")
                {
                    IQueryable<vwIntroductionGameResult> query = (from p in db.vwIntroductionGameResults select p);
                    if (!string.IsNullOrEmpty(id))
                        query = query.Where(p => p.id.ToString() == id);
                    if (!string.IsNullOrEmpty(name))
                        query = query.Where(p => p.name.ToString() == name);

                    var tempq = query.ToList();
                    var query2 = tempq.GroupBy(t => t.name);
                    var data = pager != null ? query2.Skip(pager.Skip).Take(pager.Take).ToList() : query2.ToList();
                    rowCount = query2.Count();

                    var query3 = data.Select(r => new vwIntroductionGameResult
                    {
                        AparatLink = r.First().AparatLink,
                        id = r.First().id,
                        name = r.First().name,
                        publisher = r.First().publisher,
                        publish_date = r.First().publish_date,
                        gameName2 = r.First().gameName2,
                        version_id = r.Max(x => x.version_id),
                        Picture = r.Any(q => q.fileTypeId == 7)
                            ? string.Join(",", r.Where(q => q.fileTypeId == 7).Select(q => q.Picture).Distinct())
                            : string.Join(",", r.Where(q => (q.version_id == r.Max(x => x.version_id) && (q.fileTypeId == 2)))
                            .Select(q => q.Picture).Distinct()),
                        //Picture = r.Any(q => q.fileTypeId == 7)
                        //        ? string.Join(",", r.Where(q => q.fileTypeId == 7).Select(q => q.Picture).Distinct())
                        //        : (r.Any(q => q.fileTypeId == 2)
                        //        ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct())
                        //        : ""),
                        PictureCover = r.Where(q => q.fileTypeId == 3 && !string.IsNullOrEmpty(q.Picture) && q.version_id == r.Max(x => x.version_id)).Select(q => q.Picture).Distinct().FirstOrDefault(),


                        intro_gameplay = r.First().intro_gameplay ?? "",
                        intro_intro = r.First().intro_intro ?? "",
                        intro_short = r.First().intro_short ?? "",
                        ParentRecommendation = r.First().ParentRecommendation ?? "",

                        source_id = r.First().source_id,
                        sourceName = r.First().virayesh,

                        esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                        categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                        genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                        platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                        esra_grade = r.First().esra_grade,

                        platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                        genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                        agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),

                    });
                    return query3.ToList();
                }
                else
                {
                    IQueryable<vwIntroductionGameResult> query = (from p in db.vwIntroductionGameResults select p);
                    if (!string.IsNullOrEmpty(name))
                        query = query.Where(p => p.name.ToString() == name);

                    var predicateP = PredicateBuilder.False<vwIntroductionGameResult>();
                    string[] platformIdList = { "1", "5", "7", "6" };
                    predicateP = platformIdList.Aggregate(predicateP,
                        (current, s) => current.OrElse(p => p.platformIdInt.ToString().Contains(s)));
                    query = query.Where(predicateP);
                    var tempq = query.ToList();
                    var query2 = tempq.GroupBy(t => t.name);
                    var data = pager != null ? query2.Skip(pager.Skip).Take(pager.Take).ToList() : query2.ToList();
                    rowCount = query2.Count();

                    var query3 = data.Select(r => new vwIntroductionGameResult
                    {
                        AparatLink = r.First().AparatLink,
                        id = r.First().id,
                        name = r.First().name,
                        publisher = r.First().publisher,
                        publish_date = r.First().publish_date,
                        gameName2 = r.First().gameName2,
                        version_id = r.Max(x => x.version_id),
                        Picture = r.Any(q => q.fileTypeId == 7)
                            ? string.Join(",", r.Where(q => q.fileTypeId == 7).Select(q => q.Picture).Distinct())
                            : string.Join(",", r.Where(q => (q.version_id == r.Max(x => x.version_id) && (q.fileTypeId == 2)))
                            .Select(q => q.Picture).Distinct()),
                        //Picture = r.Any(q => q.fileTypeId == 7)
                        //        ? string.Join(",", r.Where(q => q.fileTypeId == 7).Select(q => q.Picture).Distinct())
                        //        : (r.Any(q => q.fileTypeId == 2)
                        //        ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct())
                        //        : ""),
                        PictureCover = r.Where(q => q.fileTypeId == 3 && !string.IsNullOrEmpty(q.Picture)).Select(q => q.Picture).Distinct().FirstOrDefault(),


                        intro_gameplay = r.First().intro_gameplay ?? "",
                        intro_intro = r.First().intro_intro ?? "",
                        intro_short = r.First().intro_short ?? "",
                        ParentRecommendation = r.First().ParentRecommendation ?? "",

                        source_id = r.First().source_id,
                        sourceName = r.First().virayesh,

                        esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                        categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                        genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                        platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                        esra_grade = r.First().esra_grade,

                        platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                        genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                        agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),

                    });
                    return query3.ToList();
                }

            }
        }
        public static List<vwIntroductionGameResult> GetAllGames_introduction(string gameName, string[] ageIdList, string[] platformIdList, string[] genreIdList, string[] categoryIdList, myCommon.pager pager, out long rowCount, string orderBy, bool isAndroid)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                if (!isAndroid)
                {
                    var query = (from p in db.vwIntroductionGameResults where p.ShowInEsraWebsite == true select p);
                    var predicateP = PredicateBuilder.False<vwIntroductionGameResult>();
                    var predicateG = PredicateBuilder.False<vwIntroductionGameResult>();
                    var predicateC = PredicateBuilder.False<vwIntroductionGameResult>();////is new and need to edit

                    if (!string.IsNullOrEmpty(gameName))
                        query = query.Where(p => p.name.Contains(gameName));

                    if (ageIdList.Any())
                        query = query.Where(p => ageIdList.Contains(p.esra_grade.ToString()));

                    if (platformIdList.Any())
                    {
                        predicateP = platformIdList.Aggregate(predicateP,
                            (current, s) => current.OrElse(p => p.platformIdInt.ToString().Contains(s)));
                        query = query.Where(predicateP);
                    }

                    if (genreIdList.Any())
                    {
                        predicateG = genreIdList.Aggregate(predicateG,
                            (current, s) => current.OrElse(p => p.genreIdInt.ToString().Contains(s)));
                        query = query.Where(predicateG);
                    }

                    if (categoryIdList.Any())////is new and need to edit
                    {
                        predicateC = categoryIdList.Aggregate(predicateC,
                            (current, s) => current.OrElse(p => p.categoryId.ToString().Contains(s)));
                        query = query.Where(predicateC);
                    }

                    if (!string.IsNullOrEmpty(orderBy))
                        switch (orderBy)
                        {
                            case "GameName":
                                query = query.OrderByDescending(result => result.name);
                                break;
                            case "LastGame":
                                query = query.OrderByDescending(result => result.esra_time);
                                break;
                            case "GameYear":
                                query = query.OrderByDescending(result => result.publish_date);
                                break;
                        }
                    var tempq = query.ToList();
                    var query2 = tempq.GroupBy(t => t.name);

                    if (pager != null)
                        data = query2.Skip(pager.Skip).Take(pager.Take).ToList();
                    else
                        data = query2.ToList();
                    rowCount = query2.Count();
                    var datahb = data.ToList<IGrouping<string, vwIntroductionGameResult>>();
                    if (datahb.Count > 0)
                    {
                        //var query3 = datahb.Select(r => new vwIntroductionGameResult
                        //{
                        //    id = r.First().id,
                        //}
                        //    );

                        IEnumerable<vwIntroductionGameResult> query3 = datahb.Select(r => new vwIntroductionGameResult
                        {
                            id = r.FirstOrDefault().id,
                            name = r.FirstOrDefault().name, //r.ToList<vwIntroductionGameResult>()[0].name ?? "",
                            publisher = r.FirstOrDefault().publisher,//r.ToList<vwIntroductionGameResult>()[0].publisher,
                            publish_date = r.FirstOrDefault().publish_date,//r.ToList<vwIntroductionGameResult>()[0].publish_date,
                            gameName2 = r.FirstOrDefault().gameName2,//r.ToList<vwIntroductionGameResult>()[0].gameName2,
                            Picture = r.Any(q => q.fileTypeId == 7)
                                            ? r.FirstOrDefault().Picture
                                            : (r.Any(q => q.fileTypeId == 2) ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct()) : ""),
                            //PictureCover = r.Where(q => q.fileTypeId == 3 && !string.IsNullOrEmpty(q.Picture)).OrderByDescending(q => q.version_id).Select(q => q.Picture).Distinct().FirstOrDefault(),// ,
                            PictureCover = r.Where(q => q.fileTypeId == 3 && !string.IsNullOrEmpty(q.Picture)).OrderByDescending(q => q.version_id).FirstOrDefault().Picture ?? "",


                            intro_gameplay = r.FirstOrDefault().intro_gameplay ?? "",//r.ToList<vwIntroductionGameResult>()[0].intro_gameplay ?? "",
                            intro_intro = r.FirstOrDefault().intro_intro ?? "",//r.ToList<vwIntroductionGameResult>()[0].intro_intro ?? "",
                            intro_short = r.FirstOrDefault().intro_short ?? "",//r.ToList<vwIntroductionGameResult>()[0].intro_short ?? "",
                            ParentRecommendation = r.FirstOrDefault().ParentRecommendation ?? "",//r.ToList<vwIntroductionGameResult>()[0].ParentRecommendation ?? "",

                            source_id = r.FirstOrDefault().source_id,//r.ToList<vwIntroductionGameResult>()[0].source_id,

                            esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                            categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                            genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                            platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                            esra_grade = r.FirstOrDefault().esra_grade,//r.ToList<vwIntroductionGameResult>()[0].esra_grade,

                            platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                            genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                            agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),
                            ShowInEsraWebsite = r.FirstOrDefault().ShowInEsraWebsite ?? false//r.ToList<vwIntroductionGameResult>()[0].ShowInEsraWebsite

                        });


                        return query3.Count() > 0 ? query3.ToList() : null;


                    }
                    else
                        return null;
                }
                else
                {
                    var query = (from p in db.vwIntroductionMobileNot where p.ShowInEsraWebsite == true select p);
                    //if(isAndroid)
                    //{

                    //    foreach (var t in query)
                    //    {
                    //        var ert = (from qw in db.tblVersionCategories where qw.IdVersion == t.version_id select qw).Count();
                    //        if(ert>0)
                    //        {

                    //        }
                    //        else
                    //        {
                    //            query = from a in query where a != t select a;
                    //        }
                    //    }
                    //}
                    var predicateP = PredicateBuilder.False<vwIntroductionMobileNot>();
                    var predicateG = PredicateBuilder.False<vwIntroductionMobileNot>();
                    var predicateC = PredicateBuilder.False<vwIntroductionMobileNot>();////is new and need to edit

                    if (!string.IsNullOrEmpty(gameName))
                        query = query.Where(p => p.name.Contains(gameName));

                    if (ageIdList.Any())
                        query = query.Where(p => ageIdList.Contains(p.esra_grade.ToString()));

                    if (platformIdList.Any())
                    {
                        predicateP = platformIdList.Aggregate(predicateP,
                            (current, s) => current.OrElse(p => p.platformIdInt.ToString().Contains(s)));
                        query = query.Where(predicateP);
                    }

                    if (genreIdList.Any())
                    {
                        predicateG = genreIdList.Aggregate(predicateG,
                            (current, s) => current.OrElse(p => p.genreIdInt.ToString().Contains(s)));
                        query = query.Where(predicateG);
                    }

                    if (categoryIdList.Any())////is new and need to edit
                    {
                        predicateC = categoryIdList.Aggregate(predicateC,
                            (current, s) => current.OrElse(p => p.categoryId.ToString().Contains(s)));
                        query = query.Where(predicateC);
                    }

                    if (!string.IsNullOrEmpty(orderBy))
                        switch (orderBy)
                        {
                            case "GameName":
                                query = query.OrderByDescending(result => result.name);
                                break;
                            case "LastGame":
                                query = query.OrderByDescending(result => result.esra_time);
                                break;
                            case "GameYear":
                                query = query.OrderByDescending(result => result.publish_date);
                                break;
                        }
                    var tempq = query.ToList();
                    var query2 = tempq.GroupBy(t => t.name);
                    var data = pager != null ? query2.Skip(pager.Skip).Take(pager.Take).ToList() : query2.ToList();
                    rowCount = query2.Count();

                    var query3 = data.Select(r => new vwIntroductionGameResult
                    {
                        id = r.First().id,
                        name = r.First().name,
                        publisher = r.First().publisher,
                        publish_date = r.First().publish_date,
                        gameName2 = r.First().gameName2,
                        Picture = r.Any(q => q.fileTypeId == 7)
                                        ? r.First().Picture
                                        : (r.Any(q => q.fileTypeId == 2) ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct()) : "")

                                        ,
                        PictureCover = r.Where(q => q.fileTypeId == 3 && !string.IsNullOrEmpty(q.Picture)).OrderByDescending(q => q.version_id).Select(q => q.Picture).Distinct().FirstOrDefault(),// ,


                        intro_gameplay = r.First().intro_gameplay ?? "",
                        intro_intro = r.First().intro_intro ?? "",
                        intro_short = r.First().intro_short ?? "",
                        ParentRecommendation = r.First().ParentRecommendation ?? "",

                        source_id = r.First().source_id,

                        esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                        esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                        categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                        genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                        platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                        esra_grade = r.First().esra_grade,

                        platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                        genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                        agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),
                        ShowInEsraWebsite = r.First().ShowInEsraWebsite

                    });


                    return query3.ToList();
                }

            }
        }
        public static List<vwIntroductionGameResult> GetRelatedGames_introduction(int id)
        {
            if (id > 0)
                using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
                {
                    //var query = (from p in db.vwIntroductionGameResults
                    //             where p.id == id
                    //             select p).First();
                    var query = from p in db.vwIntroductionGameResults
                                where p.id == id
                                select p;
                    var hb1 = query.ToList<vwIntroductionGameResult>();

                    vwIntroductionGameResult query2h = new vwIntroductionGameResult();
                    query2h = hb1[0];

                    if (query2h != null && query2h.id > 0)
                    {

                        //var reQuery = (from p in db.vwIntroductionGameResults
                        //               where
                        //                   (p.platformID=="1"/*.Contains(query.platformID)*/ &&
                        //                    p.esra_grade == query.esra_grade &&
                        //                    p.genreID == query.genreID) &&
                        //                   (p.id != id)
                        //               select p);
                        IQueryable<vwIntroductionGameResult> reQuery = (from p in db.vwIntroductionGameResults select p);
                        if (query2h.esra_grade != null)
                            reQuery = reQuery.Where(p => p.esra_grade == query2h.esra_grade);
                        if (query2h.platformIdInt != null)
                            reQuery = reQuery.Where(p => p.platformIdInt == query2h.platformIdInt);
                        if (query2h.genreIdInt != null)
                            reQuery = reQuery.Where(p => p.genreIdInt == query2h.genreIdInt);
                        if (query2h.id != null)
                            reQuery = reQuery.Where(p => p.id != query2h.id);
                        //var predicateP = PredicateBuilder.False<vwIntroductionGameResult>();
                        //string[] platformIdList = { "1", "5", "7", "6" };
                        //predicateP = platformIdList.Aggregate(predicateP,
                        //    (current, s) => current.OrElse(p => p.platformIdInt.ToString().Contains(s)));
                        //query = query.Where(predicateP);




                        var tempq = reQuery.ToList();

                        var query2 = tempq.GroupBy(t => t.name);

                        var data = query2.Take(2);
                        var query3 = data.Select(r => new vwIntroductionGameResult
                        {
                            id = r.First().id,
                            name = r.First().name,
                            publisher = r.First().publisher,
                            publish_date = r.First().publish_date,
                            gameName2 = r.First().gameName2,
                            //Picture = r.Any(q => q.fileTypeId == 2) ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct()) : "",
                            PictureCover = r.Where(q => q.fileTypeId == 3 && q.Picture != null && q.Picture != "").Select(q => q.Picture).Distinct().FirstOrDefault(),


                            intro_gameplay = r.First().intro_gameplay ?? "",
                            intro_intro = r.First().intro_intro ?? "",
                            intro_short = r.First().intro_short ?? "",
                            ParentRecommendation = r.First().ParentRecommendation ?? "",

                            source_id = r.First().source_id,

                            esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                            categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                            genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                            platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                            esra_grade = r.First().esra_grade,

                            platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                            genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                            agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),

                        });


                        return query3.ToList();
                    }
                    return null;
                }
            else return null;
        }
        public static List<vwIntroductionGameResult> GetRelatedGames_introductionByAge(int age)
        {
            if (age > 0)
                using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
                {
                    var query = (from p in db.vwIntroductionGameResults
                                 where p.esra_grade == age
                                 select p);
                    query = query.Where(q => q.platformIdInt != 8 && q.platformIdInt != 9);

                    var tempq = query.ToList();

                    var query2 = tempq.GroupBy(t => t.name);

                    var data = query2.Take(2);
                    if (data.Any())
                    {
                        var query3 = data.Select(r => new vwIntroductionGameResult
                        {
                            id = r.First().id,
                            name = r.First().name,
                            publisher = r.First().publisher,
                            publish_date = r.First().publish_date,
                            gameName2 = r.First().gameName2,
                            //Picture = r.Any(q => q.fileTypeId == 2) ? string.Join(",", r.Where(q => q.fileTypeId == 2).Select(q => q.Picture).Distinct()) : "",
                            PictureCover = r.Where(q => q.fileTypeId == 3 && q.Picture != null && q.Picture != "").Select(q => q.Picture).Distinct().FirstOrDefault(),



                            intro_gameplay = r.First().intro_gameplay ?? "",
                            intro_intro = r.First().intro_intro ?? "",
                            intro_short = r.First().intro_short ?? "",
                            ParentRecommendation = r.First().ParentRecommendation ?? "",

                            source_id = r.First().source_id,

                            esra_anomalies = (int)(r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 5).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_despair = (int)(r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 6).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_drugs = (int)(r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 1).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_fear = (int)(r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 3).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_skill = (int)(r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 2).Select(q => q.pictogramRate).Distinct().Max() : 0),//5
                            esra_violence = (int)(r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Any() ? r.Where(q => q.pictogramId == 4).Select(q => q.pictogramRate).Distinct().Max() : 0),//5

                            categoryIdTemp = string.Join(",", r.Select(q => q.categoryId).Distinct()),

                            genreID = string.Join(",", r.Select(q => q.genreIdInt).Distinct()),
                            platformID = string.Join(",", r.Select(q => q.platformIdInt).Distinct()),
                            esra_grade = r.First().esra_grade,

                            platformsTitle = string.Join(",", r.Select(q => q.platformsTitle).Distinct()),
                            genresTitle = string.Join(",", r.Select(q => q.genresTitle).Distinct()),
                            agesTitle = string.Join(",", r.Select(q => q.agesTitle).Distinct()),

                        });

                        return query3.ToList();
                    }
                    return null;
                }
            else return null;
        }
    }
}
