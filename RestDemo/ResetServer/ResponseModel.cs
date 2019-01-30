using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ResetServer
{
    public enum ResponseEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 1000
    }

    public class ResponseModel
    {
        public int code { get; set; }
        public string info { get; set; }
        public string errmsg { get; set; }
        public DataTable data { get; set; }

        public ResponseModel(int _code, string _info, string _errmsg, DataTable _data)
        {
            this.code = _code;
            this.info = _info;
            this.errmsg = _errmsg;
            this.data = _data;
        }
    }
}
