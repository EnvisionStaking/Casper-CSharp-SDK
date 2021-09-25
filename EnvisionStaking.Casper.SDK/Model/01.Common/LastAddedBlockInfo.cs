using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class LastAddedBlockInfo
    {
        public string hash { get; set; }
        public DateTime timestamp { get; set; }
        public int era_id { get; set; }
        public int height { get; set; }
        public string state_root_hash { get; set; }
        public string creator { get; set; }
    }
}
