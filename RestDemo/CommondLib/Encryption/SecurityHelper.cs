using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace CommondLib.Encryption
{
    public class SecurityHelper
    {
        // DES默认密钥向量
        public static string key = "auaspp01";
        static byte[] KeysDES = Encoding.UTF8.GetBytes(key);//{ 0x61, 0x75, 0x61, 0x73, 0x70, 0x70, 0x30, 0x31 }; // { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="key">加密密钥,要求为8位</param>
        /// <param name="input">输入字符串</param>
        /// <param name="err">出错消息</param>
        /// <returns>加密成功返回解密后的字符串，失败返源串</returns>
        public static string EncryptDES(string key, string input)
        {
            string ret = string.Empty;
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(rgbKey, KeysDES), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                ret = Base64.Encrypt(mStream.ToArray());
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return ret;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="key">解密密钥,要求为8位,和加密密钥相同</param>
        /// <param name="input">输入字符串</param>
        /// <param name="err">出错消息</param>
        public static string DecryptDES(string key, string input)
        {
            string ret = string.Empty;
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                byte[] inputByteArray = Base64.Decrypt(input);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(rgbKey, KeysDES), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                ret = Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return ret;
        }
    }
}
