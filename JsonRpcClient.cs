    using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Jayrock.Json;
using System.IO;
using Jayrock.Json.Conversion;

namespace SevenShadow.GAIuS
{

    class JSONService
    {
        string url;
        public JSONService(string url_)
        {
            url = url_;
        }

        public object Call(JsonObject jsonrequest)
        {
            
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/plain";

            webRequest.Method = "POST";
            TextWriter writer = new StreamWriter(webRequest.GetRequestStream());
            writer.Write(jsonrequest.ToString());
            writer.Close();
            WebResponse response = webRequest.GetResponse();
            ImportContext import = new ImportContext();
            JsonReader reader = new JsonTextReader(new StreamReader(response.GetResponseStream()));
            object jsonresponse_ = import.Import(reader);
            if (!(jsonresponse_ is JsonObject))
                throw new Exception("Something weird happened to the request, check the foobar or something");

            JsonObject jsonresponse = (JsonObject)jsonresponse_;

            if (jsonresponse["error"] != null)
                throw new Exception(jsonresponse["error"].ToString());

            return jsonresponse["result"];
        }

        
       
    }


}

