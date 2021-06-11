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
using Esra.Dal;
using Esra.DalBpms;
using Esra.COMMON;

namespace Esra.ConvertToBpms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void ConvertIntroduction()
        {


            //            var publisher = queryGameName.Select(p => p.publisher.TrimStart()).ToList().Distinct();
            //            List<Organization> organizationslList = publisher.Select(s1 => new Organization
            //            {
            //                Type = 0,
            //                Parent = 0,
            //                AutomaticCoding = false,
            //                IsMyOrganization = false,
            //                Name = s1
            //            }).ToList();
            //
            //            dbBpms.Organizations.InsertAllOnSubmit(organizationslList);
            //            dbBpms.SubmitChanges();
            //
            //            var queryOrganization = from p in dbBpms.Organizations
            //                                    select p;
            //            foreach (Organization organization in queryOrganization)
            //            {
            //                dbBpms.tblOrganizationBonyads.InsertOnSubmit(new tblOrganizationBonyad
            //                {
            //                    Id = organization.Id,
            //                    IdCountry = 0,
            //                    IdAreaActivity = 0,
            //                    Allowed = false,
            //                    IsCommercial = false,
            //
            //                });
            //            }
            //            dbBpms.SubmitChanges();
            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //                dbBpms.tblGames.InsertOnSubmit(new tblGame
            //                {
            //                    Name = introduction.name.Trim(),
            //                    Name2 = "",
            //                    IdProducer = queryOrganization.Single(p => p.Name.Contains(introduction.publisher.Trim())).Id,
            //                    PublishDateTime = new DateTime(int.Parse(introduction.publish_date.ToString()), 1, 1)
            //                });
            //            }
            //            dbBpms.SubmitChanges();
            //            var dbSource = from p in db.sources select p;
            //            var dbPlatform = from p in db.platforms select p;
            //            var dbGenres = from p in db.genres select p;
            //            var dbBpmsGame = from p in dbBpms.tblGames select p;
            //            var dbBpmsPlatform = from p in dbBpms.tblPlatforms select p;
            //            var dbBpmsGenres = from p in dbBpms.tblCategories
            //                               where p.IdCategoryType == 1
            //                               select p;
            //            var dbAge = from p in db.ages select p;
            //            var dbBpmsEsra = from p in dbBpms.tblEsras select p;
            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //                foreach (string s in introduction.platformID.Split(','))
            //                {
            //                    if (!string.IsNullOrEmpty(s))
            //                    {
            //                        tblVersion tempTblVersion = new tblVersion();
            //
            //                        tempTblVersion.IdPlatform = dbBpmsPlatform.Single(p => p.Name == dbPlatform.Single(q => q.id.ToString() == s).title).Id;
            //                        tempTblVersion.IsSourceAvailable = false;
            //                        tempTblVersion.IdSourceType = introduction.source_id == 1 ? 1 : 2;
            //                        tempTblVersion.IdGame = dbBpmsGame.Single(p => p.Name == (introduction.name.TrimStart())).Id;
            //                        tempTblVersion.ReleaseDateTime = new DateTime(int.Parse(introduction.publish_date.ToString()), 1, 1);
            //                        tempTblVersion.IntroductionMin = introduction.intro_short;
            //                        tempTblVersion.Introduction = "";
            //                        tempTblVersion.GamePlay = introduction.intro_intro;
            //                        tempTblVersion.ParentRecommendation = introduction.intro_gameplay;
            //                        tempTblVersion.IdQuality = 0;
            //                        tempTblVersion.Deficiency = false;
            //                        tempTblVersion.IdProducer = queryOrganization.Single(p => p.Name == introduction.publisher.TrimStart()).Id;
            //                        tempTblVersion.IdEditableType = 0;
            //                        tempTblVersion.IdLanguage = 0;
            //                        tempTblVersion.IdUser = 0;
            //
            //                        dbBpms.tblVersions.InsertOnSubmit(tempTblVersion);
            //                    }
            //                }
            //
            //            }
            //            dbBpms.SubmitChanges();
            //            var dbBpmsVersion = from p in dbBpms.tblVersions select p;
            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //                foreach (string s in introduction.platformID.Split(','))
            //                {
            //                    if (!string.IsNullOrEmpty(s))
            //                    {
            //                        int gameId = (from p in dbBpms.tblGames
            //                                      where p.Name == introduction.name.TrimStart()
            //                                      select p).Single().Id;
            //                        foreach (tblVersion result in dbBpmsVersion.Where(p => p.IdGame == gameId))
            //                        {
            //                            tblVersionEsra tempVersionEsra = new tblVersionEsra();
            //                            tempVersionEsra.IdVersion = result.Id;
            //                            tempVersionEsra.IdEsra = Convert.ToInt32(introduction.esra_grade);
            //                            tempVersionEsra.CreationDateTime = DateTime.Now;
            //                            tempVersionEsra.IdUser = 0;
            //
            //                            dbBpms.tblVersionEsras.InsertOnSubmit(tempVersionEsra);
            //                        }
            //                    }
            //                }
            //            }
            //            dbBpms.SubmitChanges();
            //
            //
            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //
            //                int gameId = (from p in dbBpms.tblGames
            //                              where p.Name == introduction.name.TrimStart()
            //                              select p).Single().Id;
            //                var queryVersion = dbBpmsVersion.Where(p => p.IdGame == gameId);
            //                foreach (tblVersion result in queryVersion)
            //                {
            //
            //
            //                    if (introduction.esra_anomalies > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 5;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_anomalies);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                    if (introduction.esra_despair > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 6;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_despair);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                    if (introduction.esra_drugs > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 1;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_drugs);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                    if (introduction.esra_fear > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 3;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_fear);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                    if (introduction.esra_skill > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 2;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_skill);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                    if (introduction.esra_violence > 0)
            //                    {
            //                        tblVersionPictogram tempVersionPictogram = new tblVersionPictogram();
            //                        tempVersionPictogram.IdVersion = result.Id;
            //                        tempVersionPictogram.IdPictogram = 4;
            //                        tempVersionPictogram.Rate = Convert.ToInt32(introduction.esra_violence);
            //                        dbBpms.tblVersionPictograms.InsertOnSubmit(tempVersionPictogram);
            //                    }
            //                }
            //            }
            //            dbBpms.SubmitChanges();
            //
            //
            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //
            //                int gameId = (from p in dbBpms.tblGames
            //                              where p.Name == introduction.name.TrimStart()
            //                              select p).Single().Id;
            //                foreach (tblVersion result in dbBpmsVersion.Where(p => p.IdGame == gameId))
            //                {
            //
            //                    foreach (string s in introduction.genreID.Split(','))
            //                    {
            //                        if (!string.IsNullOrEmpty(s))
            //                        {
            //                            tblVersionGenre tempVersionGenre = new tblVersionGenre();
            //                            tempVersionGenre.IdVersion = result.Id;
            //                            if (s == "1") tempVersionGenre.IdGenre = 3;
            //                            else if (s == "2") tempVersionGenre.IdGenre = 4;
            //                            else if (s == "3") tempVersionGenre.IdGenre = 5;
            //                            else if (s == "4") tempVersionGenre.IdGenre = 6;
            //                            else if (s == "5") tempVersionGenre.IdGenre = 7;
            //                            else if (s == "6") tempVersionGenre.IdGenre = 8;
            //                            else if (s == "7") tempVersionGenre.IdGenre = 9;
            //                            else if (s == "8") tempVersionGenre.IdGenre = 10;
            //                            else if (s == "9") tempVersionGenre.IdGenre = 11;
            //                            else if (s == "10") tempVersionGenre.IdGenre = 12;
            //                            else if (s == "11") tempVersionGenre.IdGenre = 13;
            //                            else if (s == "13") tempVersionGenre.IdGenre = 14;
            //                            else tempVersionGenre.IdGenre = Convert.ToInt32(s);
            //                            dbBpms.tblVersionGenres.InsertOnSubmit(tempVersionGenre);
            //                        }
            //                    }
            //
            //                }
            //            }
            //            dbBpms.SubmitChanges();

            //
            //            foreach (games_introduction introduction in queryGameName)
            //            {
            //                int gameId = (from p in dbBpms.tblGames
            //                              where p.Name == introduction.name.TrimStart()
            //                              select p).Single().Id;
            //                foreach (tblVersion result in dbBpmsVersion.Where(p => p.IdGame == gameId))
            //                {
            //                    string[] allImg = introduction.Picture.Split(',').Where(o => !string.IsNullOrEmpty(o)).ToArray();
            //                    Array.Sort(allImg);
            //                    for (int i = 0; i < allImg.Count(); i++)
            //                    {
            //                        if (!string.IsNullOrEmpty(allImg[i]))
            //                        {
            //                            tblFile tempFile = new tblFile();
            //                            tempFile.Name = allImg[i];
            //                            tempFile.UploadDateTime = DateTime.Now;
            //                            dbBpms.tblFiles.InsertOnSubmit(tempFile);
            //                            dbBpms.SubmitChanges();
            //
            //                            tblVersionScreenshot tempVersionScreenshot = new tblVersionScreenshot();
            //                            tempVersionScreenshot.IdVersion = result.Id;
            //                            tempVersionScreenshot.IdFile = tempFile.Id;
            //                            tempVersionScreenshot.IdScreenshotType = i == 0 ? 3 : 2;
            //                            dbBpms.tblVersionScreenshots.InsertOnSubmit(tempVersionScreenshot);
            //                            dbBpms.SubmitChanges();
            //
            //                            System.Threading.Thread.Sleep(200);
            //                        }
            //                    }
            //                }
            //            }


            try
            {
                DataClassesDataContext db = new DataClassesDataContext();
                DataClassesBPMSDataContext dbBpms = new DataClassesBPMSDataContext();
                Thread t = new Thread(() =>
                {
                    var queryGameName = (from p in db.games_introductions
                                         select p).ToList();
                    foreach (games_introduction introduction in queryGameName)
                    {
                        rchResult.Text += $"{introduction.id} - {introduction.name}\r\n";
                        rchResult.SelectionStart = rchResult.Text.Length;
                        rchResult.ScrollToCaret();
                        System.Threading.Thread.Sleep(100);
                    }
                    rchResult.Text += $"-------------------------------------------\r\n";
                    foreach (games_introduction introduction in queryGameName)
                    {
                        int gameId = (from p in dbBpms.tblGames
                                      where p.Name.Trim() == introduction.name.TrimStart()
                                      select p).Single().Id;
                        string source = $@"C:\websites\esra_sadati\uploads\picture\game\gamePic\{introduction.id}";
                        string destination = $@"C:\websites\esra_sadati\uploads\picture\game\aa\{gameId}";
                        rchResult.Text += $"folder {introduction.id} ";


                        //                        var result = MessageBox.Show("انتقال فولدر انجام شود؟", "عملیات انتقال", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        //                        if (result == DialogResult.Yes)
                        //                        {
                        try
                        {
                            Directory.Move(source, destination);
                            rchResult.Text += $"successfuly moved \r\n{source}\r\n{destination}\r\n";
                        }
                        catch (Exception exception)
                        {
                            rchResult.Text += $"{exception.Message}\r\n{source}\r\n{destination}\r\n\r\n";
                        }
                        //                        }
                        //                        if (result == DialogResult.No)
                        //                            rchResult.Text += $"folder {introduction.id} NOT moved\r\n\r\n";
                        //                        if (result == DialogResult.Cancel)
                        //                            break;
                        rchResult.SelectionStart = rchResult.Text.Length;
                        rchResult.ScrollToCaret();
                        System.Threading.Thread.Sleep(100);
                    }
                });
                t.Start();
            }
            catch (Exception exception)
            {
                rchResult.Text = exception.Message;
            }

        }
        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            ConvertIntroduction();
        }
    }

}
