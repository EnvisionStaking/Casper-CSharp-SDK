using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Withdraw
    {
        public string bonding_purse { get; set; }
        public string validator_public_key { get; set; }
        public string unbonder_public_key { get; set; }
        public int era_of_creation { get; set; }
        public string amount { get; set; }
    }
}
