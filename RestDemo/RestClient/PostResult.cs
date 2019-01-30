using Newtonsoft.Json.Linq;
using System.Data;

namespace RestClient
{
    class PostResult
    {
        public bool IsSuccess { get; set; }
        public string Info { get; set; }
        public string ErrMsg { get; set; }
        public DataTable Data { get; set; }
        public string Des { get; set; }
    }
}
