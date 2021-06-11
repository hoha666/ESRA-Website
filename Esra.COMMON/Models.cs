using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable All

namespace Esra.COMMON
{
    public class Models
    {
        public class GameModel
        {
            public class Version
            {
                public string id { get; set; }
                public int platformVer { get; set; }
                public int sourceType { get; set; }
                public int ratingStatus { get; set; }
                public int isSourseAvalable { get; set; }
                public int ageRan { get; set; }
                public List<string> criminalContent { get; set; }
                public List<string> classification { get; set; }
                public string quality { get; set; }
                public int deficiency { get; set; }
                public string deficiencyNote { get; set; }
            }

            public class Genre
            {
                public string id { get; set; }
                public string main { get; set; }
                public string sub { get; set; }
            }

            public class GameInfo
            {
                public string gameId { get; set; }
                public string gName { get; set; }
                public string gName2 { get; set; }
                public string componyCreated { get; set; }
                public string yearPublished { get; set; }
                public string internalPublisher { get; set; }
                public string esra_summary { get; set; }
                public List<Version> versions { get; set; }
                public List<Genre> genres { get; set; }
                public List<string> img { get; set; }
            }

            public class GameIntroInfo
            {
                public string gName { get; set; }
                public string Publisher { get; set; }
                public string GenreID { get; set; }
                public string platformID { get; set; }
                public string sourceID { get; set; }
                public string yearPublished { get; set; }
                public string intro_short { get; set; }
                public string intro_intro { get; set; }
                public string intro_gameplay { get; set; }
                public string ReviewersScore { get; set; }
                public string esra_grade { get; set; }
                public string esra_skill { get; set; }
                public string esra_violence { get; set; }
                public string esra_fear { get; set; }
                public string esra_drugs { get; set; }
                public string esra_anomalies { get; set; }
                public string esra_despair { get; set; }
                public List<string> img { get; set; }
            }
        }
    }
}