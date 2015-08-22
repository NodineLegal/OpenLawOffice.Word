using System;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace OpenLawOffice.Word
{
    public static class Extensions
    {
        public static T JsonDeserialize<T>(this Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(stream))
            {
                //string str = sr.ReadToEnd();
                //if (Globals.ThisAddIn.CanLog)
                //    LogManager.GetCurrentClassLogger().Debug("Deserializing: " + str);
                //return JsonConvert.DeserializeObject<T>(str);
                using (JsonTextReader jtr = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<T>(jtr);
                }
            }
        }

        public static bool DynamicPropertyExists(dynamic dyn, string name)
        {
            return dyn.GetType().GetProperty(name) != null;
        }
    }
}
