using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busTbl_NewsCategory
    {
        public static List<Tbl_NewsCategory> GetAllNewsCategories(int id)
        {
            return dalTbl_NewsCategory.GetAllNewsCategories(id);


        }
    }
}
