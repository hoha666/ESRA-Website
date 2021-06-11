using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busContents
    {
        public static List<content> GetAllContents()
        {
            return dalContents.GetAllContents();
        }
    }
}
