using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busTbl_firstPageSection
    {
        public static int InsertOneFirstPageSection(Tbl_FirstPageSection pageSection)
        {
            return dalTbl_firstPageSection.InsertOneFirstPageSection(pageSection);
        }

        public static List<Tbl_FirstPageSection> GetAllFirstPageSection(int id)
        {
            return dalTbl_firstPageSection.GetAllFirstPageSection(id);
        }

        public static bool UpdateOneFirstPageSection(Tbl_FirstPageSection pageSection, int id)
        {
            return dalTbl_firstPageSection.UpdateOneFirstPageSection(pageSection, id);
        }

        public static bool DeleteOneFirstPageSection(int id)
        {
            return dalTbl_firstPageSection.DeleteOneFirstPageSection(id);
        }
    }
}
