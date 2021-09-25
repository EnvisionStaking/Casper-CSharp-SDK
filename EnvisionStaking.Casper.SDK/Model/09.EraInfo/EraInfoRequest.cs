using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Era
{
    class EraInfoRequest : Base.Request
    {
        public EraInfoRequest()
        {
            this.method = "chain_get_era_info_by_switch_block";
        }

        public EraInfoRequest(string blockIdentifier)
        {
            this.method = "chain_get_era_info_by_switch_block";
            this.Parameters = new EraInfoParameters() { block_identifier = blockIdentifier };
        }

        [JsonProperty("params")]
        public EraInfoParameters Parameters { get; set; }
    }
}