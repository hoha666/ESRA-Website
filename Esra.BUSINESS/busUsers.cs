
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.Dal;
using Esra.COMMON;

namespace Esra.BUSINESS
{
    public class busUsers
    {
        public static user GetUserInfo(string userName)
        {
            return dalUsers.GetUserInfo(userName);
        }
    }
}
