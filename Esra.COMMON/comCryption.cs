using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Esra.COMMON
{
    public class comCryption
    {
        public static string EncryptString(string strToEncrypt)
        {
            UTF8Encoding ue = new UTF8Encoding();
            byte[] bytes = ue.GetBytes(strToEncrypt);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);
            // Bytes to string
            strToEncrypt= System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "").ToLower();
            return strToEncrypt;
        }
    }
}
