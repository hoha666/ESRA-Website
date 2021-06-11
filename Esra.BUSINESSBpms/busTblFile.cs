using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.BUSINESSBpms
{
    public static class busTblFile
    {
        public static List<tblFile> GetAlltblFiles()
        {
            return DalBpms.DalTblFile.GetAlltblFiles();
        }
        public static tblFile GetOnetblFiles(string name)
        {
            return DalBpms.DalTblFile.GetOnetblFiles(name);
        }
        public static List<tblFile>  GetOnetblFiles(string name , string idversion)
        {
            return DalBpms.DalTblFile.GetOnetblFiles(name,idversion);
        }
        
        public static int InsertOnetblFiles(tblFile file)
        {
            return DalBpms.DalTblFile.InsertOnetblFiles(file);
        }
        public static bool UpdateOnetblFiles(int id, string name, tblFile file)
        {
            return DalBpms.DalTblFile.UpdateOnetblFiles(id, name, file);
        }
        public static bool DeleteOnetblFiles(int id, string name)
        {
            return DalBpms.DalTblFile.DeleteOnetblFiles(id, name);
        }
    }
}
