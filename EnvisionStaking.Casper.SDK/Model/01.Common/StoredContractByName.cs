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

        [JsonIgnore]
        public List<KeyValuePair<string, CLValue>> argsObject
        {
            get
            {
                List<KeyValuePair<string, CLValue>> result = new List<KeyValuePair<string, CLValue>>();

                foreach (var row in argsJson)
                {
                    result.Add(new KeyValuePair<string, CLValue>(row[0].ToString(), JsonConvert.DeserializeObject<CLValue>(row[1].ToString())));
                }

                return result;
            }
            set
            {
                List<List<object>> jsonObject = new List<List<object>>();

                foreach (var row in value)
                {
                    List<object> temp = new List<object>();
                    temp.Add(row.Key);
                    temp.Add(row.Value);
                    jsonObject.Add(temp);
                }
                if(argsJson == null)
                {
                    argsJson = new List<List<object>>();
                }
                argsJson = jsonObject;
            }
        }
    }
}
 
