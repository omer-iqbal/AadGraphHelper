using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadGraphApiHelper
{
    class RequestHistoryManager
    {
        private static RequestHistoryManager s_RequestHistoryManager = new RequestHistoryManager();
        public List<RequestHistoryObject> RequestHistoryObjects
        {
            get;private set;
        }

        public RequestHistoryManager()
        {
            if (File.Exists(StorageFileName))
            {
                string json = File.ReadAllText(StorageFileName);
                RequestHistoryObjects = JsonConvert.DeserializeObject<List<RequestHistoryObject>>(json);

                // temp code to remove duplicates if present during load
                var temp = new List<RequestHistoryObject>();
                foreach (var requestHistoryObject in RequestHistoryObjects)
                {
                    if (!temp.Exists(x => x.Url == requestHistoryObject.Url))
                        temp.Add(requestHistoryObject);
                }

                RequestHistoryObjects = temp;
            }
            else
            {
                RequestHistoryObjects = new List<RequestHistoryObject>();
            }
        }

        public static RequestHistoryManager Instance
        {
            get { return s_RequestHistoryManager; }
        }

        public void AddRequest(string method, string url, string body)
        {
            if (RequestHistoryObjects.Exists(x => x.Url.Equals(url)))
                return;
            RequestHistoryObjects.Add(new RequestHistoryObject(method, url, body));
            SaveHistoryToDisk();
        }

        private void SaveHistoryToDisk()
        {
            string json = JsonConvert.SerializeObject(RequestHistoryObjects);

            if (!Directory.Exists(StorageDir))
            {
                Directory.CreateDirectory(StorageDir);
            }

            File.WriteAllText(StorageFileName, json);
        }

        private string StorageFileName
        {
            get
            {
                string filePath = Path.Combine(StorageDir, "history.json");
                return filePath;
            }
        }

        private string StorageDir
        {
            get
            {
                string dirPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AADGraphHelper");
                return dirPath;
            }
        }
    }


}
