using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
     public class busAges
    {
        public static List<age> GetAllAges()
        {
            return dalAges.GetAllAges();
        }
    }
}
