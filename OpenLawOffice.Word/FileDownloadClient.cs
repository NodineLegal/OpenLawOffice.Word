using System;
using System.Net;
using System.IO;
using System.Text;
using NLog;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{
    public class FileDownloadClient
    {
        public class DownloadResult
        {
            public string Error { get; set; }
            public bool Success { get; set; }
        }

        public static DownloadResult DownloadFile(string uri, Stream localFileStream)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            
            // create request
            webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = "GET";
            webRequest.Accept = "application/octet-stream";

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
                LogManager.GetCurrentClassLogger().Debug("Sending request to: " + uri);

            // read response
            try
            {
                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (Exception ex)
            {
                return new DownloadResult()
                {
                    Success = false,
                    Error = ex.Message
                };
            }

            using (Stream stream = webResponse.GetResponseStream())
            {
                byte[] buffer = new byte[4096];
                long totalBytesRead = 0;
                int bytesRead;
                    
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                    localFileStream.Write(buffer, 0, bytesRead);
                }
            }

            localFileStream.Flush();
            localFileStream.Close();
            localFileStream.Dispose();
                
            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Debug("Received: " + uri);

            return new DownloadResult()
            {
                Success = true
            };
        }
    }
}
