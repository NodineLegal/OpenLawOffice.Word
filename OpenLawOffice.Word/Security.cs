using System;
using OpenLawOffice.Common.Net;
using NLog;
using Newtonsoft.Json;

namespace OpenLawOffice.Word
{
    public class Security
    {
        public Guid? Token { get; set; }

        private bool _isConnected = false;
        public bool IsConnected { get { return _isConnected; } }

        public Security()
        {
            Token = null;
            _isConnected = false;
        }

        public Response<dynamic> CloseSession()
        {
            JsonWebClient web;
            Response<bool> result;
            string url;
            Response<dynamic> resp;
            AuthPackage authPackage;

            if (string.IsNullOrEmpty(Globals.ThisAddIn.Settings.ServerUrl))
                throw new InvalidOperationException("Invalid Server URL");
            if (string.IsNullOrEmpty(Globals.ThisAddIn.Settings.Username))
                throw new InvalidOperationException("Invalid Username");

            authPackage = new AuthPackage()
            {
                AppName = "OpenLawOffice.Word",
                MachineId = Globals.ThisAddIn.Settings.MachineId,
                Username = Globals.ThisAddIn.Settings.Username.Trim()
            };

            web = new JsonWebClient();
            url = Globals.ThisAddIn.Settings.ServerUrl + "JsonInterface/CloseSession";

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Debug("Sending authentication request to: " + url);

            result = web.Request<AuthPackage, bool>(url, "POST", authPackage);
            resp = new Common.Net.Response<dynamic>();

            if (result == null)
            {
                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Info("Error closing session.");

                resp.RequestReceived = result.RequestReceived;
                resp.ResponseSent = result.ResponseSent;
                resp.Successful = result.Successful;
                resp.Package = new
                {
                    Error = web.GetResult<bool>().Error,
                    Server = Globals.ThisAddIn.Settings.ServerUrl.Trim()
                };
            }
            else
            {
                resp.RequestReceived = result.RequestReceived;
                resp.ResponseSent = result.ResponseSent;
                resp.Successful = result.Successful;
                resp.Package = null;

                _isConnected = false;
                Token = null;

                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Debug("Session closed successfully.");
            }

            return resp;
        }

        public Response<dynamic> Authenticate(string password)
        {
            JsonWebClient web;
            AuthPackage authPackage;
            Response<Guid> result;
            string authUrl;
            Response<dynamic> resp;
            Common.Encryption enc;
            Common.Encryption.Package encPackage;

            enc = new Common.Encryption();
            enc.Key = Globals.ThisAddIn.Settings.Key;
            enc.GenerateIV();
            encPackage = new Common.Encryption.Package()
            {
                Input = password.Trim()
            };
            encPackage = enc.Encrypt(encPackage);

            authPackage = new AuthPackage()
            {
                AppName = "OpenLawOffice.Word",
                MachineId = Globals.ThisAddIn.Settings.MachineId,
                Username = Globals.ThisAddIn.Settings.Username.Trim(),
                IV = enc.IV,
                Password = encPackage.Output
            };

            if (string.IsNullOrEmpty(Globals.ThisAddIn.Settings.ServerUrl))
                throw new InvalidOperationException("Invalid Server URL");
            if (string.IsNullOrEmpty(Globals.ThisAddIn.Settings.Username))
                throw new InvalidOperationException("Invalid Username");

            web = new JsonWebClient();
            authUrl = Globals.ThisAddIn.Settings.ServerUrl + "JsonInterface/Authenticate";

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Debug("Sending authentication request to: " + authUrl);

            result = web.Request<AuthPackage, Guid>(authUrl, "POST", authPackage);
            resp = new Common.Net.Response<dynamic>();

            if (result == null)
            {
                string error;

                if (Globals.ThisAddIn.CanLog)
                    LogManager.GetCurrentClassLogger().Info("Login error for user: " + authPackage.Username);

                resp.Successful = false;
                try
                {
                    error = web.GetResult<Guid>().Error;
                }
                catch
                {
                    error = null;
                }

                resp.Package = new
                {
                    Error = error,
                    Username = authPackage.Username,
                    Server = Globals.ThisAddIn.Settings.ServerUrl.Trim()
                };

                Token = null;
            }
            else
            {
                resp.RequestReceived = result.RequestReceived;
                resp.ResponseSent = result.ResponseSent;
                resp.Successful = result.Successful;
                if (string.IsNullOrEmpty(result.Error))
                {
                    resp.Package = new
                    {
                        Token = result.Package,
                        Username = authPackage.Username,
                        Server = Globals.ThisAddIn.Settings.ServerUrl.Trim()
                    };
                }
                else
                {
                    resp.Package = new
                    {
                        Error = result.Error,
                        Token = result.Package,
                        Username = authPackage.Username,
                        Server = Globals.ThisAddIn.Settings.ServerUrl.Trim()
                    };
                }

                _isConnected = true;

                if (result.Package != null && result.Package != Guid.Empty)
                    Token = result.Package;

                if (Globals.ThisAddIn.CanLog)
                {
                    if (resp.Successful)
                        LogManager.GetCurrentClassLogger().Debug("User logged in successfully: " + authPackage.Username);
                    else
                        LogManager.GetCurrentClassLogger().Debug("Failed login for: " + authPackage.Username);
                }
            }

            return resp;
        }

        private static string Hash(string str)
        {
            System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            bytes = sha512.ComputeHash(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}
