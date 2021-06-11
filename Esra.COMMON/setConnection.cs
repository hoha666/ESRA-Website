using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esra.COMMON
{
    class setConnection
    {
    }
    public partial class DataClassesDataContext
    {
        public DataClassesDataContext() :
            base(ConfigurationManager.AppSettings["esra_sadatiConnectionString1"].ToString())
        {
            OnCreated();
        }
    }
    public partial class DataClassesBPMSDataContext
    {
        public DataClassesBPMSDataContext() :
            base(ConfigurationManager.AppSettings["CloudNasirConnectionString"].ToString())
        {
            OnCreated();
        }
    }
}
