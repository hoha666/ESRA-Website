using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busSub_genres
    {
        public static List<sub_genre> GetAllSubGenres()
        {
            return dalSub_genres.GetAllSubGenres();
        }
    }
}
