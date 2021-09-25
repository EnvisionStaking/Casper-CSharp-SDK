using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.StateRootHash
{
    public class StateRootHashRequest : Base.Request
    {
        public StateRootHashRequest()
        {
            this.method = "chain_get_state_root_hash";
        }
        public StateRootHashRequest(string blockIdentifier)
        {
            this.method = "chain_get_state_root_hash";
            this.Parameters = new StateRootHashParameters() { block_identifier = blockIdentifier };
        }
        [JsonProperty("params")]
        public StateRootHashParameters Parameters { get; set; }
    }
}