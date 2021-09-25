using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Bid
    {
        public string bonding_purse { get; set; }
        public string staked_amount { get; set; }
        public int delegation_rate { get; set; }
        public List<Delegator> delegators { get; set; }
        public bool inactive { get; set; }
    }
}
