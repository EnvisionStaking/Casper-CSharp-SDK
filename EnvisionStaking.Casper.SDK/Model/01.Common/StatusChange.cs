using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class StatusChange
    {
        public int era_id { get; set; }
        public string validator_change { get; set; }
    }
}
