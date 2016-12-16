using Jayrock.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenShadow.GAIuS
{
    public class GAIuSResponse : IGAIuSResponse
    {
        public ResponseStatus Status { get; set; }
        public Message Message { get; set; }
        public string RawResponse { get; set; }
        public JsonObject JsonRequest  { get; set; }
        public string RawRequest { get; set; }
        public GAIuSPrediction Prediction { get; set; }
        public GAIuSResponse()
        {
       
        }

        public GAIuSResponse(JObject jsonObject, JsonObject jsonRequest)
        {
            JsonRequest = jsonRequest;

            if (jsonObject["status"].ToString() == "ok")
                Status = ResponseStatus.OK;
            else
                Status = ResponseStatus.Error;

            Message = new Message();
            RawResponse = jsonObject.ToString();
            RawRequest = JsonRequest.ToString();
            //Message.LastAction = jsonObject["message"]["last_action"].ToString();


        }
    }

    public class GAIuSPrediction
    {
        public string id { get; set; }
        public string interval { get; set; }
        public string status { get; set; }
        public long time_stamp { get; set; }
        public string message { get; set; }
        public List<GAIuSMessage> Messages { get; set; }
    }

    public class GAIuSMessageTest
    {
        public string confluence { get; set; }
        /* 
      public string confidence { get; set; }

      public string name { get; set; }
      //public string missing { get; set; }
      public List<string> matches { get; set; }
      public List<string> futures { get; set; }
      public List<string> extras { get; set; }
      public string evidence { get; set; }
      public string potential { get; set; }

      public string utility { get; set; }

      public string past { get; set; }
      public string record { get; set; }
      public double frequency { get; set; }
      public double amplitude { get; set; }
      public double amplitude2 { get; set; }
      public List<string> next { get; set; }
      public string prototypical { get; set; }
      //public List<string> present { get; set; }

      */

    }
    public class GAIuSMessage
    { 
        public string confluence { get; set; }
        public string confidence { get; set; }
        public string name { get; set; }
        //public string missing { get; set; }
        public List<string> matches { get; set; }
        public List<string> futures { get; set; }
        public List<string> extras { get; set; }
        public string evidence { get; set; }
        public string potential { get; set; }

        public string utility { get; set; }

        /* public string past { get; set; }
        public string record { get; set; }
        public double frequency { get; set; }
        public double amplitude { get; set; }
        public double amplitude2 { get; set; }
        public List<string> next { get; set; }
        public string prototypical { get; set; }
        //public List<string> present { get; set; }
        
        */

    }
}
