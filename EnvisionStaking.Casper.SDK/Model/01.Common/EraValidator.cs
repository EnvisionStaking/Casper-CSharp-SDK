using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class EraValidator
    {
        public int era_id { get; set; }
        public List<ValidatorWeight> validator_weights { get; set; }
    }
}
