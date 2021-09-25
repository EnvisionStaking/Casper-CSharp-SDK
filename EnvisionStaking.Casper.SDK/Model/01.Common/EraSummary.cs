using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class EraSummary
    {
        public string block_hash { get; set; }
        public int era_id { get; set; }
        public string merkle_proof { get; set; }
        public string state_root_hash { get; set; }
        public StoredValue stored_value { get; set; }
    }
}
