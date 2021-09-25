using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AuctionInfo
{
    public class AuctionInfoRequest : Base.Request
    {
        public AuctionInfoRequest()
        {
            this.method = "state_get_auction_info";
        }        
    }
}
