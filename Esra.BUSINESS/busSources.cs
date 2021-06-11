using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busSources
    {
        public static List<source> GetAllSource()
        {
            return dalSources.GetAllSource();
        }
    }
}