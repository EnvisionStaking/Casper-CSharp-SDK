using EnvisionStaking.Casper.SDK.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    [Serializable]
    public class CLValue
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CLType.CLTypeEnum cl_type { get; set; }
        public string bytes { get; set; }
        public object parsed { get; set; }

        public byte[] ToBytes()
        {
            return ByteUtil.HexToByteArray(bytes);
        }
    }
}
