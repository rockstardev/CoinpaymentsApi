using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Coinpayments.Api
{
    public class CryptoUtil
    {
        public static string CalcSignature(string input, string key = null)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = getHasher(key))
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        private static HashAlgorithm getHasher(string key)
        {
            if (key == null)
            {
                return HMACSHA512.Create();
            }
            else
            {
                byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                return new HMACSHA512(keyBytes);
            }
        }
        
        public static string DictionaryToFormData(Dictionary<string,string> dict)
        {
            var query = string.Join("&", dict.Keys.Select(key => string.Format("{0}={1}",
                key, HttpUtility.UrlEncode(dict[key]))));

            return query;
        }
    }
}
