using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class SeigniorageAllocation
    {
        public SeigniorageDelegator Delegator { get; set; }
        public SeigniorageValidator Validator { get; set; }
    }
}
