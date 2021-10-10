using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Utils
{
    /// <summary>
    /// This util includes helper methods for Json 
    /// </summary>
    public static class JsonUtil
    {
        /// <summary>
        /// JSON Serializer setting 
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings JsonSerializerSettings()
        {
            JsonSerializerSettings formatSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
            return formatSettings;
        }
    }
}
