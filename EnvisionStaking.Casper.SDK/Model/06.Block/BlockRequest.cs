using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Block
{
    class BlockRequest : Base.Request
    {
        public BlockRequest()
        {
            this.method = "chain_get_block";
        }

        public BlockRequest(string blockIdentifier)
        {
            this.method = "chain_get_block";
            this.Parameters = new BlockParameters() { block_identifier = blockIdentifier };
        }

        [JsonProperty("params")]
        public BlockParameters Parameters { get; set; }
    }
}