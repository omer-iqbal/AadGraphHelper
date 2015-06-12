using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AadGraphApiHelper
{
    internal class Request
    {
        internal string AccessToken { get; set; }

        internal Request(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        internal HttpStatusCode Send(string method, string url, string body, out string response)
        {
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Authorization", this.AccessToken);
            request.ContentType = @"application/json";
            request.Method = method.ToUpperInvariant();

            if (!String.IsNullOrWhiteSpace(body))
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(body);
                }
            }

            try
            {
                using (WebResponse webResponse = request.GetResponse())
                {
                    HttpWebResponse httpWebResponse = webResponse as HttpWebResponse;

                    if (httpWebResponse == null)
                    {
                        throw new InvalidOperationException("Web response is not an http response.");
                    }

                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                        {
                            response = streamReader.ReadToEnd();
                        }
                    }

                    return httpWebResponse.StatusCode;
                }
            }
            catch (WebException exception)
            {
                Stream stream = exception.Response.GetResponseStream();
                string errorResponseText;
                using (StreamReader reader = new StreamReader(stream))
                {
                    response = reader.ReadToEnd();
                }

                HttpWebResponse httpWebResponse = (HttpWebResponse)exception.Response;
                return httpWebResponse.StatusCode;
            }
        }
    }
}
