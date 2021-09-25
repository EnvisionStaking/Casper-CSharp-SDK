using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.BlockTransfers
{
    class BlockTransfersRequest : Base.Request
    {
        public BlockTransfersRequest()
        {
            this.method = "chain_get_block_transfers";
        }

        public BlockTransfersRequest(string blockIdentifier)
        {
            this.method = "chain_get_block_transfers";
            this.Parameters = new BlockTransfersParameters() { block_identifier = blockIdentifier };
        }

        [JsonProperty("params")]
        public BlockTransfersParameters Parameters { get; set; }
    }
}