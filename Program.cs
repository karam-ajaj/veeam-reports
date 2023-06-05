using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Data;
using Aspose.Cells;
using Aspose.Cells.Utility;
using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;


namespace RESTfulAPIConsume
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();
            
            //post request
            var postRequest = (HttpWebRequest)WebRequest.Create(RequestConstants.SessionRequestUrl);
            var postData = "" + Uri.EscapeDataString("");
            var data = Encoding.ASCII.GetBytes(postData);
            postRequest.Method = "POST";
            postRequest.ContentType = "application/x-www-form-urlencoded";
            postRequest.ContentLength = 0;
            postRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(RequestConstants.auth));
            //Console.WriteLine(RequestConstants.auth);
            using (var stream = postRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)postRequest.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // get request:
            // define the download URL and download the JSON file to local storage
            WebRequest getRequest = WebRequest.Create(RequestConstants.GetReportsUrl);
            getRequest.Method = "GET";
            getRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(RequestConstants.auth));
            // error post and get should be in the same session to get the data back
            HttpWebResponse getResponse = getRequest.GetResponse() as HttpWebResponse;
            // display response on console
            //documentation: https://docs.microsoft.com/en-us/dotnet/api/system.net.webrequest?view=net-6.0
            // Get the stream containing content returned by the server.
            Stream dataStream = getResponse.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            getResponse.Close();
            
            // write JSON reponse to local file
            //File.WriteAllText(RequestConstants.path_json, responseFromServer);
            

            Console.WriteLine(getResponse);
            Console.ReadLine();
            Console.WriteLine("done");
        }

        public static string GetId(IRequestHandler requestHandler)
        {
            return requestHandler.GetId(RequestConstants.APIUrl);
        }

        
        
    }
}