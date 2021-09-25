using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class BlockHeader
    {
        public string parent_hash { get; set; }
        public string state_root_hash { get; set; }
        public string body_hash { get; set; }
        public bool random_bit { get; set; }
        public string accumulated_seed { get; set; }
        public object era_end { get; set; }
        public DateTime timestamp { get; set; }
        public int era_id { get; set; }
        public int height { get; set; }
        public string protocol_version { get; set; }
    }
}
