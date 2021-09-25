using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class SeigniorageDelegator
    {
        public string amount { get; set; }
        public string delegator_public_key { get; set; }
        public string validator_public_key { get; set; }
    }
}
