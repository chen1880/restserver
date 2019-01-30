using System;
using System.Data;
using System.ServiceModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommondLib.Encryption;

namespace ResetServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class JsonService : IService
    {
        public string Test()
        {
            return JsonConvert.SerializeObject(new ResponseModel((int)ResponseEnum.Success, "ok", "", new DataTable()));
        }

        public string MultiParam(string strParam1, string strParam2)
        {
            Console.WriteLine("执行函数 [MultiParam]");
            return Response("strParam1=" + strParam1 + ",strParam2=" + strParam2, ResponseEnum.Success, "ok", "", new DataTable());
        }

        public string GetDataTable(string strSql)
        {
            Console.WriteLine("执行函数 [GetDataTable]");
            DataTable dt = QueryDB(strSql);
            return Response("strSql=" + strSql, ResponseEnum.Success, "ok", "", dt);
        }

        public string GetDataTable_DES(string strSql)
        {
            Console.WriteLine("执行函数 [GetDataTable_DES]");
            // 解密
            string strInput = SecurityHelper.DecryptDES(SecurityHelper.key, strSql);
            DataTable dt = QueryDB(strInput);
            string info = JsonConvert.SerializeObject(dt, new DataTableConverter());// [{"field1":"value10","field2":"value20"},{"field1":"value11","field2":"value21"}]
            // 加密
            info = SecurityHelper.EncryptDES(SecurityHelper.key, info);
            return Response("strSql=" + strSql, ResponseEnum.Success, info, "", new DataTable());
        }

        public string ExecuteNonQuery(string strSql)
        {
            Console.WriteLine("执行函数 [ExecuteNonQuery]");
            return Response("strSql=" + strSql, ResponseEnum.Success, "1", "", new DataTable());
        }

        public string ExecuteNonQuery_DES(string strSql)
        {
            Console.WriteLine("执行函数 [ExecuteNonQuery_DES]");
            // 解密
            string strInput = SecurityHelper.DecryptDES(SecurityHelper.key, strSql);
            // 加密
            string info = "1";
            info = SecurityHelper.EncryptDES(SecurityHelper.key, info);
            return Response("strSql=" + strSql, ResponseEnum.Success, info, "", new DataTable());
        }

        string Response(string input, ResponseEnum status, string info, string errmsg, DataTable data)
        {
            string ret = JsonConvert.SerializeObject(new ResponseModel((int)ResponseEnum.Success, info, errmsg, data));
            Console.WriteLine("输入 " + input);
            Console.WriteLine("输出 " + ret + "\r\n");
            return ret;
        }

        DataTable QueryDB(string strSql)
        {
            DataTable dt = new DataTable("tb");
            dt.Columns.Add("field1", System.Type.GetType("System.String"));
            dt.Columns.Add("field2", System.Type.GetType("System.String"));
            for (int i = 0; i < 2; i++)
            {
                DataRow dr = dt.NewRow();
                dr["field1"] = "value1" + i;
                dr["field2"] = "value2" + i;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
