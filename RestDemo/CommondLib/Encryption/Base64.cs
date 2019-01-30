using System;
using System.Text;

namespace CommondLib.Encryption
{
    class Base64
    {
        public static string Encrypt(byte[] data)
        {
            string ret = string.Empty;
            try { ret = System.Convert.ToBase64String(data); } catch { }
            return ret;
        }

        public static byte[] Decrypt(string val)
        {
            byte[] ret = null;
            try { ret = System.Convert.FromBase64String(val); } catch { }
            return ret;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeString(string val)
        {
            string ret = "";
            Encoding encode = Encoding.UTF8;
            byte[] bytes = encode.GetBytes(val);
            try { ret = Convert.ToBase64String(bytes); } catch { }
            return ret;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeString(string val)
        {
            string ret = "";
            Encoding encode = Encoding.UTF8;
            byte[] bytes = Convert.FromBase64String(val);
            try { ret = encode.GetString(bytes); } catch { }
            return ret;
        }
    }
}
