using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace Esra.WebUI.Common
{
    public class UICommon
    {
        public static bool Sendmail2(string mreveiver, string mtitle, string mcontent)
        {
            try
            {
                
                string SMTP_Title = ConfigurationManager.AppSettings["SMTP_Title"].ToString();
                string SMTP_Server = ConfigurationManager.AppSettings["SMTP_Server"].ToString();
                string SMTP_user = ConfigurationManager.AppSettings["SMTP_user"].ToString();
                string SMTP_password = ConfigurationManager.AppSettings["SMTP_password"].ToString();
                string SMTP_default_mail = ConfigurationManager.AppSettings["SMTP_default_mail"].ToString();
                string SMTP_port = ConfigurationManager.AppSettings["SMTP_port"].ToString();


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP_Server);


                mail.From = new MailAddress(SMTP_default_mail, SMTP_Title);
                mail.To.Add(mreveiver);
                mail.Subject = mtitle;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = mcontent;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpServer.Port = int.Parse(SMTP_port);
                SmtpServer.Credentials = new System.Net.NetworkCredential(SMTP_user, SMTP_password);
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public class Message
        {
            public String Text
            {
                get; set;
            }
            public String Receptor
            {
                get;
                set;
            }
            public String Sender
            {
                get; set;
            }
            public String SendDate
            {
                get; set;
            }

        }

    }
    public static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            return serializer.Serialize(obj);
        }

        public static string ToJson(this object obj, int recursionDepth)
        {
            var serializer = new JavaScriptSerializer { RecursionLimit = recursionDepth };
            serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
            return serializer.Serialize(obj);
        }
    }

    class NullPropertiesConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var jsonExample = new Dictionary<string, object>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                //check if decorated with ScriptIgnore attribute
                bool ignoreProp = prop.IsDefined(typeof(ScriptIgnoreAttribute), true);

                var value = prop.GetValue(obj, BindingFlags.Public, null, null, null);
                if (value != null && !ignoreProp)
                    jsonExample.Add(prop.Name, value);
            }

            return jsonExample;
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return GetType().Assembly.GetTypes(); }
        }
    }
}
