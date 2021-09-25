using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class JsonBid
    {
        public string validator_public_key { get; set; }
        public string bonding_purse { get; set; }
        public string staked_amount { get; set; }
        public int delegation_rate { get; set; }
        public object vesting_schedule { get; set; }
        public JObject delegators { get; set; }
        public bool inactive { get; set; }
    }
}
