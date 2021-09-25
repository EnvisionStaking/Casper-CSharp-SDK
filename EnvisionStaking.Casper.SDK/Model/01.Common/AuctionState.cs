using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class AuctionState
    {
        public string state_root_hash { get; set; }
        public int block_height { get; set; }
        public List<EraValidator> era_validators { get; set; }
        public List<BidRoot> bids { get; set; }
    }
}
