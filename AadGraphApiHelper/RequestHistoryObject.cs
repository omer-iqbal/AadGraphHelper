using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadGraphApiHelper
{
    class RequestHistoryObject
    {
        public RequestHistoryObject(string method, string url, string body)
        {
            Method = method;
            Url = url;
            this.Body = body;
        }

        public string Method { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
    }
}
