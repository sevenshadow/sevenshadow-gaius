using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using Jayrock;
using System.ComponentModel;
using System.Reflection;
using Jayrock.Json;
namespace SevenShadow.GAIuS
{
    public enum GAIuSMethod
    {
        [Description("showStatus")]
        ShowStatus = 0,

        [Description("startModelLearning")]
        StartModelLearning = 1,

        [Description("stopModelLearning")]
        StopModelLearning = 2,

        [Description("observe")]
        Observe = 3,

        [Description("clearWM")]
        ClearSystemMemory = 4,

        [Description("getPredictions")]
        GetPredictions = 5,

       
        [Description("bulkLearning")]
        BulkLearning = 6,

        [Description("showPredictionsInfoBundle")]
        ShowPredictionsInfoBundle = 7,

        [Description("setPredictions")]
        SetPredictions = 8,

        [Description("clearAllMemory")]
        ClearAllMemory = 9,

        [Description("showTIC")]
        showTic = 10,

        [Description("ping")]
        Ping = 11,

        [Description("noAction")]
        NoAction = 12,

       
    }

    public class GAIuSData
    {
        public object[] strings { get; set; }
        public object[] vectors { get; set; }
        public object[] scalars { get; set; }
        public object[] tags { get; set; }
    }

    public class GAIuSHelper
    {
        public string BaseUrl = "http://charlie.intelligent-artifacts.net:4110/primitive/jsonrpc";

        private JSONService _service;

        #region Constructors

        public GAIuSHelper()
        {
            _service = new JSONService(BaseUrl);
        }

        public GAIuSHelper(string baseUrl)
        {
            BaseUrl = baseUrl;
            _service = new JSONService(BaseUrl);

        }

        #endregion

        public GAIuSResponse ShowStatus()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.ShowStatus);
            jsonrequest["params"] = new object[] { };
            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }

        public GAIuSResponse Ping()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.Ping);
            jsonrequest["params"] = new object[] { };
            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }
        public GAIuSResponse StartModelLearning()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.StartModelLearning);
            
            jsonrequest["params"] = new object[] { 1 };
            
            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }

        public GAIuSResponse Observe(GAIuSData data)
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.Observe);

            jsonrequest["params"] = new object[] { data };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }

        public GAIuSResponse GetPredictions()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.GetPredictions);

            jsonrequest["params"] = new object[] {  };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }

        public GAIuSResponse SetPredictions()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.SetPredictions);

            jsonrequest["params"] = new int[] { 1 };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }


        public GAIuSResponse StopModelLearning()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.StopModelLearning);
            
            jsonrequest["params"] = new object[] { };
            
            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }
 
        public GAIuSResponse ClearSystemMemory()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.ClearSystemMemory);
            
            jsonrequest["params"] = new int[] { };
            
            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }
        public GAIuSResponse ClearAllMemory()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.ClearAllMemory);

            jsonrequest["params"] = new int[] { };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }
        public GAIuSResponse ShowTic()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.showTic);

            jsonrequest["params"] = new int[] { };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }

        public GAIuSResponse ClearAll()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.ClearAllMemory);

            jsonrequest["params"] = new int[] { };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }
        public GAIuSResponse ShowPredictionsInfoBundle()
        {
            JsonObject jsonrequest = GetBaseJsonRequest(GAIuSMethod.ShowPredictionsInfoBundle);

            jsonrequest["params"] = new int[] { };

            object rawData = _service.Call(jsonrequest);
            return GetGAIuSResponse(rawData, jsonrequest);
        }


        public string GetCleanGaiusString(string data)
        {
            data = data.Replace("&", "_AMPERSAND_");
            data = data.Replace("(", "_OPEN_PARENTHESIS_");
            data = data.Replace(")", "_CLOSE_PARENTHESIS_");
            data = data.Replace("\\", "_BACK_SLASH_");
            data = data.Replace("[", "_OPEN_BRACKET_");
            data = data.Replace("[", "_CLOSE_BRACKET_");
            data = data.Replace("$", "_DOLLAR_SIGN_");
            data = data.Replace(".", "_DOT_");
            data = data.Replace("^", "_HAT_");
            data = data.Replace("?", "_QUESTION_MARK_");
            data = data.Replace("`", "_APOSTROPHE_");
            data = data.Replace(":", "_COLON_");
            data = data.Replace("\"", "_DOUBLE_QUOTES_");
            data = data.Replace("*", "_ASTERISK_");


            return data;
        }


        #region Private Methods

        private GAIuSResponse GetGAIuSResponse(object rawData, JsonObject jsonRequest)
        {
            string rawDataString = rawData.ToString().Replace("True", "true").Replace("False", "false");
            JObject jsonObject = JObject.Parse(rawDataString);
            GAIuSResponse response = new GAIuSResponse(jsonObject, jsonRequest);
            return response;

        }

        private JsonObject GetBaseJsonRequest(GAIuSMethod method)
        {
            JsonObject jsonrequest = new JsonObject();
            jsonrequest["jsonrpc"] = "1.0";
            jsonrequest["method"] = GetEnumDescription(method);
            jsonrequest["id"] = 1;

            return jsonrequest;
        }
        private static String GetEnumDescription(Enum e)
        {

            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0)
            {

                return enumAttributes[0].Description;

            }

            return e.ToString();

        }

        #endregion

    }


}