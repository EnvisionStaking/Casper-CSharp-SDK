using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.StateItem
{
    public class StateItemResult : Base.Result
    {
        public ResultBody result { get; set; }
    }
    public class ResultBody
    {
        public string api_version { get; set; }
        public StoredValue stored_value { get; set; }
        public string merkle_proof { get; set; }
    }  
}
