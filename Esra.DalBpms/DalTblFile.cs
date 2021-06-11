using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.DalBpms
{
    public static class DalTblFile
    {
        public static List<tblFile> GetAlltblFiles()
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                var data = (from p in db.tblFiles select p).ToList();
                return data;
            }
        }
        public static tblFile GetOnetblFiles(string name)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    var data = (from p in db.tblFiles where p.Name == name select p).Single();
                    return data;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static List<tblFile> GetOnetblFiles(string name , string idVersion)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    var data2 = (from a in db.tblVersionScreenshots join b2 in db.tblFiles on a.IdFile equals b2.Id where a.IdVersion == int.Parse(idVersion) select b2).ToList<tblFile>();
                    var data = (from p in db.tblFiles where p.Name == name  select p).Single();
                    //return data;
                    return data2;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static int InsertOnetblFiles(tblFile file)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    db.tblFiles.InsertOnSubmit(file);
                    db.SubmitChanges();
                    return file.Id;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public static bool UpdateOnetblFiles(int id, string name, tblFile file)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    tblFile data = new tblFile();
                    if (id != 0) data = (from p in db.tblFiles where p.Id == id select p).Single();
                    else if (name != "") data = (from p in db.tblFiles where p.Name == name select p).Single();

                    data.Name = file.Name;
                    data.UploadDateTime = file.UploadDateTime;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static bool DeleteOnetblFiles(int id, string name)
        {
            using (DataClassesBPMSDataContext db = new DataClassesBPMSDataContext())
            {
                try
                {
                    tblFile data = new tblFile();
                    if (id != 0) data = (from p in db.tblFiles where p.Id == id select p).Single();
                    else if (name != "") data = (from p in db.tblFiles where p.Name == name select p).Single();

                    db.tblFiles.DeleteOnSubmit(data);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}
