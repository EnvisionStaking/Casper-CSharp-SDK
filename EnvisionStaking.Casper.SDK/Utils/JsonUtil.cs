using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Utils
{
    public static class JsonUtil
    {
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
