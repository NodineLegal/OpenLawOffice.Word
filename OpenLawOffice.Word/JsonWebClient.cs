using System;
using System.Net;
using System.IO;
using System.Text;
using NLog;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{

    public class JsonWebClient
    {
        public object _result;

        public Result<OpenLawOffice.Common.Net.Response<TResponse>> GetResult<TResponse>()
        {
            return (Result<OpenLawOffice.Common.Net.Response<TResponse>>)_result;
        }

        public class Result<T>
        {
            public string Error { get; set; }
            public string Json { get; set; }
            public T Response { get; set; }
            public bool HasError { get { return !string.IsNullOrEmpty(Error); } }
        }

        public OpenLawOffice.Common.Net.Response<TResponse> Request<TResponse>(string uri, string requestType)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            Result<OpenLawOffice.Common.Net.Response<TResponse>> result = new Result<OpenLawOffice.Common.Net.Response<TResponse>>();

            // create request
            webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = requestType;
            webRequest.Accept = "application/json; charset=utf-8";

            if (Globals.ThisAddIn.Security.Token.HasValue)
            {
                webRequest.CookieContainer = new CookieContainer();
                webRequest.CookieContainer.Add(new Cookie()
                {
                    Domain = new Uri(Globals.ThisAddIn.Settings.ServerUrl).Host,
                    Name = "Token",
                    Value = Globals.ThisAddIn.Security.Token.Value.ToString()
                });
            }

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Trace("Sending request to: " + uri);

            // read response
            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
                _result = result;
                return null;
            }

            using (Stream stream = webResponse.GetResponseStream())
            {
                result.Response = stream.JsonDeserialize<OpenLawOffice.Common.Net.Response<TResponse>>();
                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Trace("Received: " + JsonConvert.SerializeObject(result.Response));
            }

            _result = result;
            return result.Response;
        }

        public OpenLawOffice.Common.Net.Response<TResponse> Request<TRequest, TResponse>(string uri, string requestType, object postData = null)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            Result<OpenLawOffice.Common.Net.Response<TResponse>> result = new Result<OpenLawOffice.Common.Net.Response<TResponse>>();

            // create request
            webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = requestType;
            webRequest.Accept = "application/json; charset=utf-8";

            if (Globals.ThisAddIn.Security.Token.HasValue)
            {
                webRequest.CookieContainer = new CookieContainer();
                webRequest.CookieContainer.Add(new Cookie()
                {
                    Domain = new Uri(Globals.ThisAddIn.Settings.ServerUrl).Host,
                    Name = "Token",
                    Value = Globals.ThisAddIn.Security.Token.Value.ToString()
                });
            }

            // add json data object to send
            if (requestType == "POST")
            {
                OpenLawOffice.Common.Net.Request<TRequest> request = new OpenLawOffice.Common.Net.Request<TRequest>();
                if (Globals.ThisAddIn.Security.Token.HasValue)
                    request.Token = Globals.ThisAddIn.Security.Token.Value;

                if (postData != null)
                    request.Package = (TRequest)postData;

                string json = JsonConvert.SerializeObject(request);

                webRequest.ContentLength = json.Length;
                try
                {
                    using (StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        sw.Write(json);
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        LogManager.GetCurrentClassLogger().Info("Failed to connect to server.");
                        MessageBox.Show("Failed to connect to server.");
                    }
                    else
                    {
                        LogManager.GetCurrentClassLogger().Error(ex);
                    }
                    return null;
                }
                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Trace("Sending: " + json);
            }
            else
                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Trace("Sending request to: " + uri);

            // read response
            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
                _result = result;
                return null;
            }

            using (Stream stream = webResponse.GetResponseStream())
            {
                result.Response = stream.JsonDeserialize<OpenLawOffice.Common.Net.Response<TResponse>>();
                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Trace("Received: " + JsonConvert.SerializeObject(result.Response));
            }

            _result = result;
            return result.Response;
        }
    }
}
