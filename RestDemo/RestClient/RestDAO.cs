using System;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using CommondLib.Encryption;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RestClient
{
    class RestDAO
    {
        string m_strUrl = "http://127.0.0.1:8888/JsonService/";

        public RestDAO(string url)
        {
            m_strUrl = url;
        }

        PostResult HttpPost(string method, string param)
        {
            PostResult ret = new PostResult();

            try
            {
                // 返回结果
                // {"code":0,"info":"ok","msg":"","data":null}
                // {"code":0,"info":"ok","msg":"","data":[{"field1":"value10","field2":"value20"},{"field1":"value11","field2":"value21"}]}
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/json");
                string jsonBack = client.UploadString(m_strUrl + method, "POST", param);
                jsonBack = jsonBack.Replace(@"\", "");                          // "{\"code\":0,\"info\":\"ok\",\"msg\":\"\",\"data\":null}"
                jsonBack = jsonBack.Substring(1, jsonBack.Length - 2);
                JObject jsonInfo = (JObject)JsonConvert.DeserializeObject(jsonBack);
                if (jsonBack.Contains("code"))
                {
                    if (0 == jsonInfo.Value<int>("code")) ret.IsSuccess = true;
                    ret.Info = jsonInfo.Value<string>("info");
                    ret.ErrMsg = jsonInfo.Value<string>("errmsg");
                    JArray arrayData = jsonInfo.Value<JArray>("data");
                    if (null != arrayData) ret.Data = JsonConvert.DeserializeObject<DataTable>(arrayData.ToString());
                }
            }
            catch (Exception ex)
            {
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }

        public PostResult Test()
        {
            return HttpPost("Test", "");
        }

        public PostResult MultiParam(string strParam1, string strParam2)
        {
            Dictionary<string, string> dicData = new Dictionary<string, string>();
            dicData.Add("strParam1", strParam1);
            dicData.Add("strParam2", strParam2);
            string strJson = JsonConvert.SerializeObject(dicData, Formatting.Indented);
            return HttpPost("MultiParam", strJson);
        }

        public PostResult GetDataTable(string strSql)
        {
            string strJson = "{\"strSql\":\"" + strSql + "\"}";
            return HttpPost("GetDataTable", strJson);
        }

        public PostResult GetDataTable_DES(string strSql)
        {
            // 加密
            strSql = SecurityHelper.EncryptDES(SecurityHelper.key, strSql);
            string strJson = "{\"strSql\":\"" + strSql + "\"}";
            PostResult ret = HttpPost("GetDataTable_DES", strJson);
            // 解密
            ret.Des = ret.Info;
            ret.Info = SecurityHelper.DecryptDES(SecurityHelper.key, ret.Info);
            return ret;
        }

        public PostResult ExecuteNonQuery(string strSql)
        {
            string strJson = "{\"strSql\":\"" + strSql + "\"}";
            return HttpPost("ExecuteNonQuery", strJson);
        }

        public PostResult ExecuteNonQuery_DES(string strSql)
        {
            // 加密
            strSql = SecurityHelper.EncryptDES(SecurityHelper.key, strSql);
            string strJson = "{\"strSql\":\"" + strSql + "\"}";
            PostResult ret = HttpPost("ExecuteNonQuery_DES", strJson);
            // 解密
            ret.Des = ret.Info;
            ret.Info = SecurityHelper.DecryptDES(SecurityHelper.key, ret.Info);
            return ret;
        }
    }
}
