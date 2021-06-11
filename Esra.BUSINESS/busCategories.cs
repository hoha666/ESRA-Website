using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busCategories
    {
        public static List<category> GetAllCategories()
        {
            return dalCategories.GetAllCategories();
        }
    }
}
