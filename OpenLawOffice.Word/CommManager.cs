using System;
using System.Collections.Generic;
using NLog;
using OpenLawOffice.Common.Net;
using System.Net;

namespace OpenLawOffice.Word
{
    public class CommManager
    {
        public static Response<List<OpenLawOffice.Common.Models.Matters.Matter>> ListMatters(string contactFilter, string titleFilter, 
            string caseNumberFilter, string jurisdictionFilter, bool activeFilter = true)
        {
            JsonWebClient web;
            OpenLawOffice.Common.Net.Response<List<OpenLawOffice.Common.Models.Matters.Matter>> response;

            web = new JsonWebClient();
            response = web.Request<List<OpenLawOffice.Common.Models.Matters.Matter>>(
                Globals.ThisAddIn.Settings.ServerUrl + "JsonInterface/Matters?contactFilter=" + contactFilter + "&titleFilter=" + titleFilter +
                "&caseNumberFilter=" + caseNumberFilter + "&jurisdictionFilter=" + jurisdictionFilter + "&activeFilter=" + activeFilter.ToString(), "GET");

            if (response != null && response.Successful)
                return new Response<List<Common.Models.Matters.Matter>>()
                {
                    Package = response.Package,
                    RequestReceived = response.RequestReceived,
                    ResponseSent = response.ResponseSent,
                    Error = response.Error,
                    Successful = response.Successful
                };

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Error("Error: " + response.Error);

            return null;
        }

        public static Response<List<OpenLawOffice.Common.Models.Forms.Form>> ListFormsForMatter(Guid matterId)
        {
            JsonWebClient web;
            OpenLawOffice.Common.Net.Response<List<OpenLawOffice.Common.Models.Forms.Form>> response;

            web = new JsonWebClient();
            response = web.Request<List<OpenLawOffice.Common.Models.Forms.Form>>(
                Globals.ThisAddIn.Settings.ServerUrl + "JsonInterface/ListFormsForMatter?matterId=" + matterId.ToString(), "GET");

            if (response != null && response.Successful)
                return new Response<List<Common.Models.Forms.Form>>()
                {
                    Package = response.Package,
                    RequestReceived = response.RequestReceived,
                    ResponseSent = response.ResponseSent,
                    Error = response.Error,
                    Successful = response.Successful
                };

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Error("Error: " + response.Error);

            return null;
        }

        public static Response<List<OpenLawOffice.Common.Models.Forms.FormFieldMatter>> GetFormDataForMatter(Guid matterId)
        {
            JsonWebClient web;
            OpenLawOffice.Common.Net.Response<List<OpenLawOffice.Common.Models.Forms.FormFieldMatter>> response;

            web = new JsonWebClient();
            response = web.Request<List<OpenLawOffice.Common.Models.Forms.FormFieldMatter>>(
                Globals.ThisAddIn.Settings.ServerUrl + "JsonInterface/GetFormDataForMatter/" + matterId.ToString(), "GET");

            if (response != null && response.Successful)
                return new Response<List<Common.Models.Forms.FormFieldMatter>>()
                {
                    Package = response.Package,
                    RequestReceived = response.RequestReceived,
                    ResponseSent = response.ResponseSent,
                    Error = response.Error,
                    Successful = response.Successful
                };

            if (Globals.ThisAddIn.CanLog)
                LogManager.GetCurrentClassLogger().Error("Error: " + response.Error);

            return null;
        }
    }
}
