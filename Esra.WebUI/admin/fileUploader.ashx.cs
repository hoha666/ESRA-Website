using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;
namespace Esra.WebUI.admin
{
    /// <summary>
    /// Summary description for fileUploader
    /// </summary>
    public class fileUploader : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string uploadPath = "temp/";

            if (!string.IsNullOrEmpty(HttpContext.Current.Session.SessionID))
            {
                string sessionId = HttpContext.Current.Session.SessionID + "/" ;
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    cFileUpload fileUpload = new cFileUpload();
                    Meta meta = new Meta();
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string newFileName = file.FileName.Replace(Path.GetExtension(file.FileName), "").Replace(" ","").Replace("'","_") + "$$_" + Guid.NewGuid().ToString()+  Path.GetExtension(file.FileName);
                        string fname = context.Server.MapPath("/./" + uploadPath+ sessionId + newFileName);
                        new FileInfo(fname).Directory?.Create();
                        file.SaveAs(fname);
                        fileUpload.files = new[] { uploadPath + newFileName };
                        meta.date = DateTime.Now;
                        meta.extension = Path.GetExtension(file.FileName).Replace(".", "");
                        meta.file = uploadPath + newFileName;
                        meta.name = newFileName;
                        meta.old_name = file.FileName;
                        meta.replaced = false;
                        meta.size = new FileInfo(fname).Length;
                        meta.size2 = new FileInfo(fname).Length / 1048576 + " MB";
                        meta.type = file.ContentType.Split('/').ToArray();
                        fileUpload.metas = new[] { meta };
                    }
                    var jsonString = JsonConvert.SerializeObject(fileUpload);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(jsonString);
                }
                else
                {
                    string fileNewName = context.Request.Form["file[metas][0][name]"];
                    string fname = context.Server.MapPath("/./" + uploadPath + sessionId + fileNewName);

                    if (File.Exists(fname))
                        File.Delete(fname);
                }
            }
        }
        public bool IsReusable => false;
    }

    public class Meta
    {
        public DateTime date;
        public string extension;
        public string file;
        public string name;
        public string old_name;
        public bool replaced;
        public long size;
        public string size2;
        public string[] type;
    }
    public class cFileUpload
    {
        public string[] files;
        public Meta[] metas;
    }
}