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

        internal string Send(string method, string url, string body = null)
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
                using (WebResponse response = request.GetResponse())
                {
                    HttpWebResponse httpWebResponse = response as HttpWebResponse;

                    if (httpWebResponse == null)
                    {
                        return "The response is not an http web response.";
                    }

                    Console.WriteLine("Status code: {0}/{1}", (int)httpWebResponse.StatusCode, httpWebResponse.StatusCode);

                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException exception)
            {
                Stream stream = exception.Response.GetResponseStream();
                string errorResponseText;
                using (StreamReader reader = new StreamReader(stream))
                {
                    errorResponseText = reader.ReadToEnd();
                }

                //HttpWebResponse response = (HttpWebResponse)exception.Response;
                //return "Error: " + exception.Status + ", " + (int)response.StatusCode + "/" + response.StatusCode + ": " + Environment.NewLine + errorResponseText;
                return errorResponseText;
            }
        }
    }
}
