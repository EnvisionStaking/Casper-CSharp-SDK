using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Delegator
    {
        public string public_key { get; set; }
        public string staked_amount { get; set; }
        public string bonding_purse { get; set; }
        public string delegatee { get; set; }
    }
}
