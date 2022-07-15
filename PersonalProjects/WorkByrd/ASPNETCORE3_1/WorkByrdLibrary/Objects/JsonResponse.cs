using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkByrdLibrary.Objects
{
    public class JsonResponse
    {
        public JsonResponse()
        {
            Response = new Dictionary<string, object>();
        }

        public JsonResponse(string key, object value, bool isSuccessResponse)
        {
            Response = new Dictionary<string, object>();

            if (isSuccessResponse)
            {
                AddSuccessData(key, value);
            }
            else
            {
                AddErrorData(key, value);
            }
        }

        public Dictionary<string, object> Response { get; set; } //hold the final json response object

        private Dictionary<string, object> Success { get; set; }
        private Dictionary<string, object> Error { get; set; }

        public void AddSuccessData(string key, object value)
        {
            if (Success == null)
            {
                Success = new Dictionary<string, object>();
            }
            Success.Add(key, value);
        }

        public void AddErrorData(string key, object value)
        {
            if (Error == null)
            {
                Error = new Dictionary<string, object>();
            }
            Error.Add(key, value);
        }

        public ContentResult GetJsonResult()
        {
            ContentResult result = new ContentResult();
            result.ContentType = "application/json"; //; charset=utf-8
            result.Content = GetJsonStringResponse();
            return result;
        }

        public string GetJsonStringResponse()
        {
            CompileResponse();
            return Newtonsoft.Json.JsonConvert.SerializeObject(Response);
        }

        public object GetRawJsonResponse()
        {
            CompileResponse();
            return Response;
        }

        private void CompileResponse()
        {
            if (Success != null)
            {
                Response.Add("Success", Success);
            }
            if (Error != null)
            {
                Response.Add("Error", Error);
            }
        }
    }
}
