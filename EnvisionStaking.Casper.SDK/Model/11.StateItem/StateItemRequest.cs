using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.StateItem
{
    class StateItemRequest : Base.Request
    {
        public StateItemRequest()
        {
            this.method = "state_get_item";
            this.Parameters = new StateItemParameters();
        }

        public StateItemRequest(string stateRootHash,  string key)
        {
            this.method = "state_get_item";
            this.Parameters = new StateItemParameters() { state_root_hash = stateRootHash, key = key };
        }

        [JsonProperty("params")]
        public StateItemParameters Parameters { get; set; }
    }
}