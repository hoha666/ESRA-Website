using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
using Esra.WebUI.Common;

namespace Esra.WebUI.admin
{
    public partial class processRequest : Page, IReadOnlySessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static void AddGame(Models.GameModel.GameInfo gameInfo)
        {
            int gameId = 0;
            Int32.TryParse(gameInfo.gameId, out gameId);
            if (gameId > 0) DeleteGame(gameInfo);
            string imgList = "";
            if (gameInfo.img.Any()) imgList = gameInfo.img.Aggregate(imgList, (current, img) => current + (img + ","));
            game g = new game
            {
                name = gameInfo.gName,
                name2 = gameInfo.gName2,
                developer = gameInfo.componyCreated,
                publish_date = Convert.ToInt64(gameInfo.yearPublished),
                icon = imgList.Replace(",", ""),
                esra_summary = gameInfo.esra_summary,
            };
            int idInsertedGame = busGames.InsertOneGame(g);
            if (idInsertedGame > 0)
            {
                foreach (Models.GameModel.Version version in gameInfo.versions)
                {
                    var v = new game_version
                    {
                        game_id = idInsertedGame,
                        platform_id = version.platformVer,
                        source_id = version.sourceType,
                        is_source_available = Convert.ToBoolean(version.isSourseAvalable),
                        result_id = version.ratingStatus,
                        age_id = version.ageRan,
                        haveproblem = Convert.ToBoolean(version.deficiency),
                        problem = version.deficiencyNote,
                        quality = version.quality,
                    };
                    int gameVersions = busGame_versions.InsertOneGame_versions(v);
                    if (gameVersions > 0)
                    {
                        foreach (string cc in version.criminalContent)
                        {
                            if (cc == "0") continue;
                            var c = new game_version_content
                            {
                                game_version_id = gameVersions,
                                content_id = Convert.ToInt32(cc)
                            };
                            busGame_version_contents.InsertOneGame_version_contents(c);
                        }
                        foreach (string cc in version.classification)
                        {
                            if (cc == "0") continue;

                            var c = new game_version_category
                            {
                                game_version_id = gameVersions,
                                category_id = Convert.ToByte(cc)
                            };
                            busGame_version_categories.InsertOneGame_version_categories(c);
                        }
                    }
                }
                foreach (Models.GameModel.Genre genre in gameInfo.genres)
                {
                    if (genre.main == "0") continue;
                    var gg = new game_genre
                    {
                        game_id = idInsertedGame,
                        genre_id = Convert.ToInt32(genre.main),
                        sub_id = Convert.ToInt32(genre.sub)
                    };
                    busGame_genres.InsertOneGame_genre(gg);
                }
            }

            string sessionId = HttpContext.Current.Session.SessionID + "\\";
            string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\icons\\";
            if (idInsertedGame > 0)
                foreach (string img in gameInfo.img)
                {
                    string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + img;

                    new FileInfo(gameFolder + idInsertedGame + "\\" + "img").Directory?.Create();
                    try
                    {
                        File.Move(tempFolder, gameFolder + idInsertedGame + "\\" + img);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

            if (gameInfo.versions.Any())
            {
                games_introduction gi = new games_introduction
                {
                    name = gameInfo.gName,
                    publisher = gameInfo.componyCreated,
                    genreID = String.Join(",", gameInfo.genres.Select(p => p.main).Distinct()),
                    platformID = String.Join(",", gameInfo.versions.Select(p => p.platformVer).Distinct()),
                    source_id = Convert.ToInt32(gameInfo.versions.Any() ? gameInfo.versions[0].sourceType : 0),
                    publish_date = Convert.ToInt64(gameInfo.yearPublished),
                    intro_short = gameInfo.esra_summary,
                    intro_intro = "",
                    intro_gameplay = "",
                    reviewers_score = Convert.ToByte(0),
                    esra_grade = Convert.ToByte(gameInfo.versions.Any() ? gameInfo.versions[0].ageRan : 0),
                    esra_skill = Convert.ToByte(0),
                    esra_violence = Convert.ToByte(0),
                    esra_fear = Convert.ToByte(0),
                    esra_drugs = Convert.ToByte(0),
                    esra_anomalies = Convert.ToByte(0),
                    esra_despair = Convert.ToByte(0),
                    Picture = imgList.Replace(",", ""),
                    categories = String.Join(",", (from version in gameInfo.versions from cc in version.classification where cc != "0" select cc).ToList().Distinct()),
                };
                int idInsertOneGames_introduction = busGames_introduction.InsertOneGames_introduction(gi);
                if (idInsertedGame > 0)
                {
                    string gameFolderIntroduction = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";
                    if (idInsertOneGames_introduction > 0)
                        foreach (string img in gameInfo.img)
                        {
                            if (!String.IsNullOrEmpty(img))
                            {
                                try
                                {
                                    string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + img;
                                    new FileInfo(gameFolderIntroduction + idInsertOneGames_introduction + "\\" + "img").Directory?.Create();
                                    File.Move(tempFolder, gameFolderIntroduction + idInsertOneGames_introduction + "\\" + img);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        File.Copy(gameFolder + idInsertedGame + "\\" + img, gameFolderIntroduction + idInsertOneGames_introduction + "\\" + img);

                                    }
                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                }
                            }
                        }
                }
            }
        }

        [WebMethod]
        public static void AddGameIntroInfo(Models.GameModel.GameIntroInfo gameIntroInfo)
        {
            string sessionId = HttpContext.Current.Session.SessionID + "\\";

            string imgList = "";
            if (gameIntroInfo.img.Any())
                imgList = gameIntroInfo.img.Aggregate(imgList, (current, img) => current + (img + ","));
            games_introduction gi = new games_introduction
            {
                name = gameIntroInfo.gName,
                publisher = gameIntroInfo.Publisher,
                genreID = gameIntroInfo.GenreID,
                platformID = gameIntroInfo.platformID,
                source_id = Convert.ToInt32(gameIntroInfo.sourceID),
                publish_date = Convert.ToInt64(gameIntroInfo.yearPublished),
                intro_short = gameIntroInfo.intro_short,
                intro_intro = gameIntroInfo.intro_intro,
                intro_gameplay = gameIntroInfo.intro_gameplay,
                reviewers_score = Convert.ToByte(gameIntroInfo.ReviewersScore),
                esra_grade = Convert.ToByte(gameIntroInfo.esra_grade),
                esra_skill = Convert.ToByte(gameIntroInfo.esra_skill),
                esra_violence = Convert.ToByte(gameIntroInfo.esra_violence),
                esra_fear = Convert.ToByte(gameIntroInfo.esra_fear),
                esra_drugs = Convert.ToByte(gameIntroInfo.esra_drugs),
                esra_anomalies = Convert.ToByte(gameIntroInfo.esra_anomalies),
                esra_despair = Convert.ToByte(gameIntroInfo.esra_despair),
                Picture = imgList
            };
            int idInsertedGame = busGames_introduction.InsertOneGames_introduction(gi);
            if (idInsertedGame > 0)
            {
                string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\gamePic\\";
                if (idInsertedGame > 0)
                    foreach (string img in gameIntroInfo.img)
                    {
                        string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId + img;
                        new FileInfo(gameFolder + idInsertedGame + "\\" + "img").Directory?.Create();
                        File.Move(tempFolder, gameFolder + idInsertedGame + "\\" + img);
                    }
            }
        }

        [WebMethod]
        public static string check_availability(string gameName)
        {
            game result = new game();
            int count = 0;
            if (!string.IsNullOrEmpty(gameName))
                result = busGames.GetOneGame(gameName, out count);
            if (result != null)
            {
                if (result.id > 0 && count == 1)
                    return "1";
                else
                    return "2";
            }
            else
                return "0";
        }

        private static void DeleteGame(Models.GameModel.GameInfo gameInfo)
        {
            int gameId = 0;
            Int32.TryParse(gameInfo.gameId, out gameId);
            List<int> deletedGameVersion = null;
            var oneGame = busGames.GetOneGame(gameId);
            string lastImg = oneGame.icon;
            string oneGameImg;

            var oneGameIntro = busGames_introduction.GetOneGames_introduction("", oneGame.name).SingleOrDefault();
            if (!String.IsNullOrEmpty(oneGameIntro?.name))
                if (!String.IsNullOrEmpty(oneGameIntro.categories))
                    busGames_introduction.DeleteOneGames_introduction(Convert.ToInt32(oneGameIntro.id), out oneGameImg);
            var deletedGame = busGames.DeleteOneGame(gameId);
            if (deletedGame)
                deletedGameVersion = busGame_versions.DeleteOneGameVersions(gameId);
            if (deletedGameVersion != null && deletedGameVersion.Any())
                foreach (int gameVersionId in deletedGameVersion)
                {
                    busGame_version_contents.DeleteOneGameVersionContents(gameVersionId);
                }
            if (deletedGameVersion != null && deletedGameVersion.Any())
                foreach (int gameVersionId in deletedGameVersion)
                {
                    busGame_version_categories.DeleteOneGameVersionCategories(gameVersionId);
                }
            if (deletedGameVersion != null && deletedGameVersion.Any())
                busGame_genres.DeleteOneGameGenres(gameId);
            string sessionId = HttpContext.Current.Session.SessionID + "\\";

            string gameFolder = HttpContext.Current.Server.MapPath("/./") + "uploads\\picture\\game\\icons\\";
            foreach (string img in lastImg.Split(','))
            {
                string tempFolder = HttpContext.Current.Server.MapPath("/./") + ("temp\\") + sessionId;
                new FileInfo(tempFolder).Directory?.Create();
                try
                {
                    File.Move(gameFolder + gameId + "\\" + img, tempFolder + img);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            try
            {
                Directory.Delete(gameFolder + gameId, true);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}