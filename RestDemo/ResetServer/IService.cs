using System.ServiceModel;
using System.ServiceModel.Web;

namespace ResetServer
{
    [ServiceContract]
    public interface IService
    {
        // 测试接口
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "Test",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string Test();

        // 多个参数接口
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "MultiParam",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string MultiParam(string strParam1, string strParam2);

        // 查询Sql语句(未加密)
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "GetDataTable",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetDataTable(string strSql);

        // 查询Sql语句(DES加密)
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "GetDataTable_DES",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetDataTable_DES(string strSql);

        // 执行Sql语句(未加密)
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "ExecuteNonQuery",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ExecuteNonQuery(string strSql);

        // 执行Sql语句(DES加密)
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "ExecuteNonQuery_DES",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ExecuteNonQuery_DES(string strSql);
    }
}
