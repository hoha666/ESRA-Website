using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
using Esra.WebUI.Common;


namespace Esra.WebUI.admin
{
    public partial class PcGameInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EditMobileGameInput.Visible = false;
                cancelEditing.Visible = false;
                BindGridView();
            }

            #region platform

            var platform = busPlatforms.GetAllPlatform().Where(p => p.title != "Android"|| p.title != "iOS"); 
            platform_ver.DataTextField = "title";
            platform_ver.DataValueField = "id";
            platform_ver.DataSource = platform;
            platform_ver.DataBind();

            #endregion

            #region sources

            var sources = busSources.GetAllSource();
            source_type.DataTextField = "title";
            source_type.DataValueField = "id";
            source_type.DataSource = sources;
            source_type.DataBind();

            #endregion

            #region ages

            var ages = busAges.GetAllAges();
            age_rang.DataTextField = "title";
            age_rang.DataValueField = "id";
            age_rang.DataSource = ages;
            age_rang.DataBind();

            #endregion

            #region contents

            var contents = busContents.GetAllContents();
            criminal_content.InnerHtml = contents.Aggregate<content, string>(null,
                (current, itemContent) =>
                    current +
                    $"<label class=\"chbox\"><input type=\"checkbox\"class=\"js-switch\"id=\"{itemContent.id}\"/>{itemContent.title}</label>");

            #endregion

            #region category

            var category = busCategories.GetAllCategories();
            classification.InnerHtml = category.Aggregate<category, string>(null,
                (current, itemCategory) =>
                    current +
                    $"<label class=\"chbox\"><input type=\"checkbox\"class=\"js-switch\"id=\"{itemCategory.id}\"/>{itemCategory.title}</label>");

            #endregion

            #region genres

            var genres = busGenres.GetAllGenres();
            slct_genres.DataTextField = "title";
            slct_genres.DataValueField = "id";
            slct_genres.DataSource = genres;
            slct_genres.DataBind();

            #endregion

            #region subGenres

            var subGenres = busSub_genres.GetAllSubGenres().Where(p => p.title != "None");
            slct_genres_sub.DataTextField = "title";
            slct_genres_sub.DataValueField = "id";
            slct_genres_sub.DataSource = subGenres;
            slct_genres_sub.DataBind();
            slct_genres_sub.Items.Insert(0, new ListItem
            {
                Text = "--------",
                Value = "0",
                Selected = true
            });

            #endregion
        }
        private void BindGridView()
        {
            var dataSource = busRatingGameResults.GetAllRatingGameResultForAdmin();

            if (dataSource.Any())
            {
                gvMobileGameInput.DataSource = dataSource;
                gvMobileGameInput.DataBind();
                gvMobileGameInput.UseAccessibleHeader = true;
                gvMobileGameInput.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                gvMobileGameInput.Columns.Clear();

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dr = dt.NewRow();
                dr["Col1"] = "رکوردی برای نمایش وجود ندارد";

                dt.Rows.Add(dr);

                gvMobileGameInput.DataSource = dt;
                gvMobileGameInput.DataBind();
            }
        }

        protected void gvMobileGameInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int gameId = Convert.ToInt32(gvMobileGameInput.Rows[e.RowIndex].Cells[0].Text); //cells 0 mean id
            List<int> deletedGameVersion = null;
            var isDeletedGame = busGames.DeleteOneGame(gameId);
            if (isDeletedGame)
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
            Response.Redirect("PcGameInput.aspx?mode=pc", true);

        }

        protected void gvMobileGameInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvMobileGameInput.Rows[e.NewEditIndex].Cells[0].Text); //cells 0 mean id
            hfselectedGameForEdit.Value = id.ToString();
            game game = busGames.GetOneGame(id);

            EditMobileGameInput.Visible = true;
            cancelEditing.Visible = true;
            txtGameName.Value = game.name;
            txtGameNameSecond.Value = game.name2;
            txtComponyCreated.Value = game.developer;
            txtYearPublished.Value = game.publish_date.ToString();
            List<game_version> gameVersion = busGame_versions.GetListGame_versions(game.id);
            List<string> imgList = game.icon?.Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList();

            string pattern = "<[^>]*>";
            Regex rgx = new Regex(pattern);

            Models.GameModel.GameInfo gameInfo = new Models.GameModel.GameInfo
            {
                gameId = game.id.ToString(),
                gName = game.name,
                gName2 = game.name2,
                componyCreated = game.developer,
                yearPublished = game.publish_date.ToString(),
                img = imgList,
                esra_summary = game.esra_summary != null ? rgx.Replace(game.esra_summary, "").Replace("\n", "") : ""
            };

            var category = busCategories.GetAllCategories();
            var contents = busContents.GetAllContents();
            gameInfo.versions = new List<Models.GameModel.Version>();
            gameInfo.genres = new List<Models.GameModel.Genre>();


            foreach (game_version version in gameVersion)
            {

                var versionCategory = busGame_version_categories.GetListGame_version_categories(version.id);
                var versionContent = busGame_version_contents.GetListGame_version_contents(version.id);

                Models.GameModel.Version tempVersion = new Models.GameModel.Version();
                List<string> classificationn = new List<string>();
                List<string> criminalContent = new List<string>();

                if (version.platform_id != null) tempVersion.platformVer = (int)version.platform_id;
                if (version.game_id != null) tempVersion.id = version.id.ToString();
                if (version.source_id != null) tempVersion.sourceType = (int)version.source_id;
                tempVersion.isSourseAvalable = version.is_source_available != null && (bool)version.is_source_available ? 1 : 0;

                if (version.result_id != null) tempVersion.ratingStatus = (int)version.result_id;
                tempVersion.deficiency = version.haveproblem != null && (bool)version.haveproblem ? 1 : 0;


                if (version.age_id != null) tempVersion.ageRan = (int)version.age_id;
                if (version.problem != null) tempVersion.deficiencyNote = version.problem;
                if (version.quality != null) tempVersion.quality = version.quality;

                for (int i = 1; i <= category.Count; i++)
                    classificationn.Add(versionCategory.Exists(c => c.category_id == i) ? i.ToString() : 0.ToString());
                tempVersion.classification = classificationn;
                for (int i = 1; i <= contents.Count; i++)
                    criminalContent.Add(versionContent.Exists(c => c.content_id == i) ? i.ToString() : 0.ToString());
                tempVersion.criminalContent = criminalContent;

                gameInfo.versions.Add(tempVersion);
            }
            var gameGenre = busGame_genres.GetListGame_genre(game.id);
            List<Models.GameModel.Genre> tempGenre = new List<Models.GameModel.Genre>();

            foreach (game_genre cGenre in gameGenre)
            {
                Models.GameModel.Genre genre = new Models.GameModel.Genre
                {
                    id = cGenre.id.ToString(),
                    main = cGenre.genre_id.ToString(),
                    sub = cGenre.sub_id.ToString()
                };
                tempGenre.Add(genre);
            }
            gameInfo.genres.AddRange(tempGenre);

            string msg = $"var gnTemp=$.parseJSON('{gameInfo.ToJson()}');";
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), Guid.NewGuid().ToString(), msg, true);
            


            gvMobileGameInput.DataSource = null;
            gvMobileGameInput.DataBind();
        }

        protected void EditMobileGameInput_OnServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PcGameInput.aspx?mode=pc", true);
        }

        protected void cancelEditing_OnServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PcGameInput.aspx?mode=pc", true);
        }
    }
}