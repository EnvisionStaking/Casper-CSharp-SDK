using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json.Converters;
using EnvisionStaking.Casper.SDK.Model.Common.Argument;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public partial class StoredContractByName
    {
        public string name { get; set; }

        public string entry_point { get; set; }

        [JsonProperty("args")]
        public List<List<object>> argsJson { get; set; }
    }
}
 
