using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esra.ConvertToBpmsRating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClassesOldSystemDataContext dbOldS = new DataClassesOldSystemDataContext();
            DataClassesBpmsDataContext dbBpms = new DataClassesBpmsDataContext();
            //var queryOldGameName = from p in dbOldS.games
            //select p;
            //var queryOrganizations = from p in dbBpms.Organizations
            //select p;
            //            var oldPublisher = queryOldGameName.Select(p => p.developer.TrimStart().TrimEnd().ToLower()).ToList().Distinct();
            //            var publisher = queryOrganizations.Select(p => p.Name.TrimStart().TrimEnd().ToLower()).ToList().Distinct();
            //            var newPublisger = oldPublisher.Except(publisher);
            //            List<Organization> organizationslList = newPublisger.Select(s1 => new Organization
            //            {
            //                Type = 0,
            //                Parent = 0,
            //                AutomaticCoding = false,
            //                IsMyOrganization = false,
            //                Name = s1
            //            }).ToList();

            //            dbBpms.Organizations.InsertAllOnSubmit(organizationslList);
            //            dbBpms.SubmitChanges();
            //
            //            var queryOrganizationBonyad = from p in dbBpms.tblOrganizationBonyads
            //                                          select p.Id;
            //            var queryOrganization = from p in dbBpms.Organizations
            //                                    where !queryOrganizationBonyad.Contains(p.Id)
            //                                    select p;

            //            foreach (Organization organization in queryOrganization)
            //            {
            //                try
            //                {
            //                    dbBpms.tblOrganizationBonyads.InsertOnSubmit(new tblOrganizationBonyad
            //                    {
            //                        Id = organization.Id,
            //                        IdCountry = 0,
            //                        IdAreaActivity = 0,
            //                        Allowed = false,
            //                        IsCommercial = false,
            //
            //                    });
            //                }
            //                catch (Exception)
            //                {
            //
            //                    throw;
            //                }
            //            }
            //            dbBpms.SubmitChanges();
            //var queryOrganizationAll = (from p in dbBpms.Organizations
            //                            select p).ToList();

            ///////////deleteeeee
            //            List<int> temoId=new List<int>();
            //            foreach (Organization organization1 in queryOrganizationAll)
            //            {
            //                foreach (Organization organization2 in queryOrganizationAll)
            //                {
            //                    if (organization1.Name.ToLower().TrimEnd() == organization2.Name.ToLower().TrimEnd() && organization1.Id!= organization2.Id)
            //                        temoId.Add(organization2.Id);
            //                    
            //                }
            //
            //            }
            //            var s = 0;
            //            var delete = from p in dbBpms.Organizations
            //                where temoId.Contains(p.Id)
            //                select p;
            //            dbBpms.Organizations.DeleteAllOnSubmit(delete);
            //            dbBpms.SubmitChanges();


            //            var clearOldGameName = queryOldGameName.ToList().GroupBy(p => p.name.TrimStart().TrimEnd().ToLower()).Select(x => x.First());
            //            foreach (game game in clearOldGameName)
            //            {
            //                tblGame tblGame = new tblGame();
            //                tblGame.Name = game.name.TrimStart().TrimEnd();
            //                tblGame.Name2 = !string.IsNullOrEmpty(game.name2) ? game.name2.TrimStart() : "";
            //                tblGame.IdProducer = queryOrganizationAll.Single(p => p.Name.TrimStart().TrimEnd().ToLower() == (game.developer.TrimStart().TrimEnd().ToLower())).Id;
            //                tblGame.PublishDateTime = game.publish_date.ToString().Contains("139")
            //                    ? new DateTime(int.Parse((game.publish_date + 621).ToString()), 1, 1)
            //                    : new DateTime(int.Parse(game.publish_date.ToString()), 1, 1);
            //                dbBpms.tblGames.InsertOnSubmit(tblGame);
            //            }
            //            dbBpms.SubmitChanges();

            //            var delete = (from p in dbBpms.tblGames select p).ToList();
            //            List<int> id = (from game1 in delete from game2 in delete where game2.Id > 1176 && game1.Name.Trim().ToLower() == game2.Name.Trim().ToLower() && game1.Id != game2.Id select game2.Id).ToList();
            //
            //            var deleteQuery = from p in dbBpms.tblGames where id.Contains(p.Id) select p;
            //            dbBpms.tblGames.DeleteAllOnSubmit(deleteQuery);
            //
            //            var ver = (from p in dbBpms.tblVersions where id.Contains(p.IdGame) select p.Id).ToList();
            //
            //            dbBpms.SubmitChanges();




            var dbSource = from p in dbOldS.sources select p;
            var dbPlatform = from p in dbOldS.platforms select p;
            var dbGenres = from p in dbOldS.genres select p;
            var dbCategories = from p in dbOldS.categories select p;
            var dbBpmsGame = (from p in dbBpms.tblGames select p).ToList();
            var dbBpmsPlatform = from p in dbBpms.tblPlatforms select p;
            var dbBpmsGenres = from p in dbBpms.tblCategories
                               where p.IdCategoryType == 1
                               select p;
            var dbAge = from p in dbOldS.ages select p;
            var dbBpmsEsra = from p in dbBpms.tblEsras select p;

            //            var versionOld = (from p in dbOldS.games
            //                              from q in dbOldS.game_versions
            //                              where q.game_id == p.id
            //                              select new
            //                              {
            //                                  id = p.id,
            //                                  name = p.name,
            //                                  name2 = p.name2,
            //                                  publish_date = p.publish_date,
            //                                  platformId = q.platform_id,
            //                                  sourceId = q.source_id,
            //                                  ageId = q.age_id,
            //                                  isSoureAvailble = q.is_source_available,
            //                                  quality = q.quality,
            //                                  esra_summary = p.esra_summary,
            //                                  problem = q.problem,
            //                                  developer = p.developer,
            //                              }).ToList();
            //            int c = 0;
            //            foreach (var v in versionOld)
            //            {
            //                tblVersion tempTblVersion = new tblVersion();
            //
            //                try
            //                {
            //                    tempTblVersion.IdPlatform = v.platformId ?? 0;
            //                    tempTblVersion.IsSourceAvailable = v.isSoureAvailble ?? false;
            //                    tempTblVersion.IdSourceType = v.sourceId == 1 ? 1 : 2;
            //                    tempTblVersion.IdGame = dbBpmsGame.Single(p => p.Name.Trim().ToLower() == (v.name.Trim().ToLower())).Id;
            //                    tempTblVersion.ReleaseDateTime = v.publish_date.ToString().Contains("139")
            //                                    ? new DateTime(int.Parse((v.publish_date + 621).ToString()), 1, 1)
            //                                    : new DateTime(int.Parse(v.publish_date.ToString()), 1, 1);
            //                    tempTblVersion.IntroductionMin = !string.IsNullOrEmpty(v.esra_summary) ? v.esra_summary : "";
            //                    tempTblVersion.Introduction = "";
            //                    tempTblVersion.GamePlay = "";
            //                    tempTblVersion.ParentRecommendation = "";
            //                    tempTblVersion.IdQuality = !string.IsNullOrEmpty(v.quality) ? (v.quality == "1" ? 1 : 4) : 0;
            //                    tempTblVersion.Deficiency = false;
            //                    tempTblVersion.IdProducer = queryOrganizationAll.Single(p => p.Name.Trim().ToLower() == v.developer.Trim().ToLower()).Id;
            //                    tempTblVersion.IdEditableType = 0;
            //                    tempTblVersion.IdLanguage = 0;
            //                    tempTblVersion.IdUser = 0;
            //
            //                    dbBpms.tblVersions.InsertOnSubmit(tempTblVersion);
            //                }
            //                catch (Exception)
            //                {
            //                    c++;
            //                }
            //
            //
            //            }
            //            dbBpms.SubmitChanges();


            var newVersion = (from p in dbBpms.tblVersions where p.IdGame > 1176 select p).ToList();
            //
            //            foreach (var v in versionOld)
            //            {
            //
            //                var g = dbBpmsGame.Single(q => q.Name.Trim().ToLower() == v.name.Trim().ToLower());
            //                var ver= newVersion.Where(p => p.IdGame ==g.Id).ToList();
            //                foreach (tblVersion verrr in ver)
            //                {
            //                    tblVersionEsra tempVersionEsra = new tblVersionEsra();
            //                    tempVersionEsra.IdVersion = verrr.Id;
            //                    tempVersionEsra.IdEsra = Convert.ToInt32(v.ageId);
            //                    tempVersionEsra.CreationDateTime = DateTime.Now;
            //                    tempVersionEsra.IdUser = 0;
            //
            //                    dbBpms.tblVersionEsras.InsertOnSubmit(tempVersionEsra);
            //                }
            //                
            //            }
            //            dbBpms.SubmitChanges();


            //            var genreOld = (from p in dbOldS.games
            //                            from q in dbOldS.game_genres
            //                            where q.game_id == p.id
            //                            select new
            //                            {
            //                                id = p.id,
            //                                name = p.name,
            //                                name2 = p.name2,
            //                                publish_date = p.publish_date,
            //                                developer = p.developer,
            //                                IdGenre = q.genre_id
            //
            //                            }).ToList();
            //var newVersion = (from p in dbBpms.tblVersions where p.IdGame > 1176 select p).ToList();
            //            List<tblVersionGenre> listVersionGenre = new List<tblVersionGenre>();
            //            foreach (var v in genreOld)
            //            {
            //
            //                var g = dbBpmsGame.Single(q => q.Name.Trim().ToLower() == v.name.Trim().ToLower());
            //                var ver = newVersion.Where(p => p.IdGame == g.Id).ToList();
            //                foreach (tblVersion verrr in ver)
            //                {
            //                    string s = v.IdGenre.ToString();
            //                    tblVersionGenre tempVersionGenre = new tblVersionGenre();
            //                    tempVersionGenre.IdVersion = verrr.Id;
            //                    if (s == "1") tempVersionGenre.IdGenre = 3;
            //                    else if (s == "2") tempVersionGenre.IdGenre = 4;
            //                    else if (s == "3") tempVersionGenre.IdGenre = 5;
            //                    else if (s == "4") tempVersionGenre.IdGenre = 6;
            //                    else if (s == "5") tempVersionGenre.IdGenre = 7;
            //                    else if (s == "6") tempVersionGenre.IdGenre = 8;
            //                    else if (s == "7") tempVersionGenre.IdGenre = 9;
            //                    else if (s == "8") tempVersionGenre.IdGenre = 10;
            //                    else if (s == "9") tempVersionGenre.IdGenre = 11;
            //                    else if (s == "10") tempVersionGenre.IdGenre = 12;
            //                    else if (s == "11") tempVersionGenre.IdGenre = 13;
            //                    else if (s == "13") tempVersionGenre.IdGenre = 14;
            //                    else if (s == "12") tempVersionGenre.IdGenre = 20;
            //                    else if (s == "14") tempVersionGenre.IdGenre = 21;
            //                    else if (s == "15") tempVersionGenre.IdGenre = 22;
            //                    else tempVersionGenre.IdGenre = Convert.ToInt32(s);
            //                    listVersionGenre.Add(tempVersionGenre);
            //                }
            //            }
            //            var dist = listVersionGenre.Distinct(new distinctTblVersionGenreComparer());
            //            dbBpms.tblVersionGenres.InsertAllOnSubmit(dist);
            //
            //            dbBpms.SubmitChanges();




            //            var gameVersionCategory = (from g in dbOldS.games
            //                            from v in dbOldS.game_versions
            //                            from c in dbOldS.game_version_categories
            //                            where g.id==v.game_id && v.id==c.game_version_id
            //                            select new
            //                            {
            //                                name = g.name,
            //                                IdCategory = c.category_id
            //
            //                            }).ToList();
            //            List<tblVersionCategory> listVersionCategories = new List<tblVersionCategory>();
            //            foreach (var v in gameVersionCategory)
            //            {
            //
            //                var g = dbBpmsGame.Single(q => q.Name.Trim().ToLower() == v.name.Trim().ToLower());
            //                var ver = newVersion.Where(p => p.IdGame == g.Id).ToList();
            //                foreach (tblVersion verrr in ver)
            //                {
            //                    string s = v.IdCategory.ToString();
            //                    tblVersionCategory tempVersionCategory = new tblVersionCategory();
            //                    tempVersionCategory.IdVersion = verrr.Id;
            //                    if (s == "1") tempVersionCategory.IdCategory = 3;
            //                    else if (s == "2") tempVersionCategory.IdCategory = 4;
            //                    else if (s == "3") tempVersionCategory.IdCategory = 5;
            //                    else if (s == "4") tempVersionCategory.IdCategory = 6;
            //                    else if (s == "5") tempVersionCategory.IdCategory = 7;
            //                    else if (s == "6") tempVersionCategory.IdCategory = 8;
            //                    else if (s == "7") tempVersionCategory.IdCategory = 9;
            //                    else if (s == "8") tempVersionCategory.IdCategory = 10;
            //                    else if (s == "9") tempVersionCategory.IdCategory = 11;
            //                    else if (s == "10") tempVersionCategory.IdCategory = 12;
            //                    else if (s == "11") tempVersionCategory.IdCategory = 13;
            //                    else tempVersionCategory.IdCategory = Convert.ToInt32(s);
            //                    listVersionCategories.Add(tempVersionCategory);
            //                }
            //            }
            //            var dist2 = listVersionCategories.Distinct(new distincttblVersionCategoryComparer());
            //            dbBpms.tblVersionCategories.InsertAllOnSubmit(dist2);
            //
            //            dbBpms.SubmitChanges();


        }
        class distinctTblVersionGenreComparer : IEqualityComparer<tblVersionGenre>
        {

            public bool Equals(tblVersionGenre x, tblVersionGenre y)
            {
                return x.IdVersion == y.IdVersion && x.IdGenre == y.IdGenre;
            }

            public int GetHashCode(tblVersionGenre obj)
            {
                return obj.IdVersion.GetHashCode() ^ obj.IdGenre.GetHashCode();
            }
        }
        class distincttblVersionCategoryComparer : IEqualityComparer<tblVersionCategory>
        {

            public bool Equals(tblVersionCategory x, tblVersionCategory y)
            {
                return x.IdVersion == y.IdVersion && x.IdCategory == y.IdCategory;
            }

            public int GetHashCode(tblVersionCategory obj)
            {
                return obj.IdVersion.GetHashCode() ^ obj.IdCategory.GetHashCode();
            }
        }

        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            DataClassesOldSystemDataContext dbOldS = new DataClassesOldSystemDataContext();
            DataClassesBpmsDataContext dbBpms = new DataClassesBpmsDataContext();
            Thread t = new Thread(() =>
            {
                var oldGame = (from p in dbOldS.games
                               where p.icon != "" && p.icon != null
                               select p).ToList();
                var newVersion = (from p in dbBpms.tblVersions where p.IdGame > 1176 select p).ToList();
                var dbBpmsGame = (from p in dbBpms.tblGames select p).ToList();
	            int i = 0;


                foreach (game game in oldGame)
                {
                    try
                    {
	                    txtCount.Text = i++.ToString();
                        tblFile tempFile = new tblFile();
                        tempFile.Name = Path.GetFileName(game.icon.Replace("/", "\\"));
                        tempFile.UploadDateTime = DateTime.Now;
                        dbBpms.tblFiles.InsertOnSubmit(tempFile);
                        dbBpms.SubmitChanges();

                        var g = dbBpmsGame.Single(q => q.Name.Trim().ToLower() == game.name.Trim().ToLower());
                        var ver = newVersion.Where(p => p.IdGame == g.Id).ToList();

                        foreach (tblVersion verrr in ver)
                        {
                            tblVersionScreenshot tempVersionScreenshot = new tblVersionScreenshot();
                            tempVersionScreenshot.IdVersion = verrr.Id;
                            tempVersionScreenshot.IdFile = tempFile.Id;
                            tempVersionScreenshot.IdScreenshotType = 7;
                            dbBpms.tblVersionScreenshots.InsertOnSubmit(tempVersionScreenshot);
                            dbBpms.SubmitChanges();
                        }

                        //rchResult.Text += $"folder {g.Id} ";

                        string source = $@"C:\websites\esra_show{game.icon}";
                        string destination = $@"C:\websites\esra_sadati\uploads\picture\game\icons\{g.Id}\{Path.GetFileName(game.icon)}";

                        try
                        {
                            Directory.CreateDirectory($@"C:\websites\esra_sadati\uploads\picture\game\icons\{g.Id}");
                            File.Copy(source, destination);

                            //rchResult.Text += $"successfuly copy \r\n{source}\r\n{destination}\r\n";
                        }
                        catch (Exception exception)
                        {
                            //rchResult.Text += $"{exception.Message}\r\n{source}\r\n{destination}\r\n\r\n";
                        }


                        //rchResult.SelectionStart = rchResult.Text.Length;
                        //rchResult.ScrollToCaret();

                    }
                    catch (Exception exception)
                    {
                        //rchResult.Text += $"{exception.Message}\r\n\r\n";
                    }
                }
            });
            t.Start();
        }
    }
}
