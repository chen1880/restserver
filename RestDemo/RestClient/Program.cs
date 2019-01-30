using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;
using CommondLib.Encryption;

namespace RestClient
{
    class Program
    {
        static string host = "http://127.0.0.1:8888/JsonService/";
        static RestDAO rest = null;
        static PostResult entity = null;

        static void Main(string[] args)
        {
            Console.WriteLine("RestClient Start, host:" + host + "\r\n");

            // 127.0.0.1或局域网ip或广域网ip
            rest = new RestDAO(host);

            entity = rest.Test();
            PrintResult("测试接口", entity);

         
            entity = rest.MultiParam("A", "B");
            PrintResult("参数接口", entity);

            entity = rest.GetDataTable("select * from tb_user");
            PrintResult("获取数据(未加密)接口", entity);

           
            entity = rest.GetDataTable_DES("select * from tb_user");
            PrintResult("获取数据(DES加密)接口", entity);

            entity = rest.ExecuteNonQuery("update tb_user set fi_Pwd='123456' where fi_ID=1");
            PrintResult("执行操作(未加密)接口", entity);

            entity = rest.ExecuteNonQuery_DES("update tb_user set fi_Pwd='123456' where fi_ID=1");
            PrintResult("执行操作(DES加密)接口", entity);

            Console.ReadLine();
        }

        static void PrintResult(string note, PostResult entity)
        {
            Console.WriteLine(note);

            if (entity.IsSuccess)
            {
                if (0 != entity.Data.Rows.Count)
                {
                    // 未加密
                    Console.WriteLine("执行结果:" + entity.IsSuccess + ",数据总数:" + entity.Data.Rows.Count);
                }
                else
                {
                    if (!string.IsNullOrEmpty(entity.Des))
                    {
                        // 已加密
                        Console.WriteLine("执行结果:" + entity.IsSuccess + ",解密前:" + entity.Des + ",解密后:" + entity.Info);
                    }
                    else
                    {
                        Console.WriteLine("执行结果:" + entity.IsSuccess + ",返回信息:" + entity.Info);
                    }
                }
            }
            else
            {
                Console.WriteLine("执行结果:" + entity.IsSuccess + ",错误信息:" + entity.ErrMsg);
            }
            Console.WriteLine("");
        }
    }
}
