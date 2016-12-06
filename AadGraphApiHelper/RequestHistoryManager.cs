using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadGraphApiHelper
{
    class RequestHistoryManager
    {
        private static RequestHistoryManager s_RequestHistoryManager = new RequestHistoryManager();
        private List<RequestHistoryObject> mRequestHistoryObjects;

        public List<RequestHistoryObject> RequestHistoryObjects
        {
            get { return mRequestHistoryObjects; }
        }

        public RequestHistoryManager()
        {
            mRequestHistoryObjects = new List<RequestHistoryObject>();
        }

        public static RequestHistoryManager Instance
        {
            get { return s_RequestHistoryManager; }
        }

        public void AddRequest(string method, string url, string body)
        {
            mRequestHistoryObjects.Add(new RequestHistoryObject(method, url, body));
        }
    }


}
