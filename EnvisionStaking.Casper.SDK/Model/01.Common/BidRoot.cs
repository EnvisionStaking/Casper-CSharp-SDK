using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class BidRoot
    {
        public string public_key { get; set; }
        public Bid bid { get; set; }
    }
}
