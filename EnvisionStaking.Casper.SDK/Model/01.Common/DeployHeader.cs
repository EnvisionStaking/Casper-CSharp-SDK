using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployHeader
    {
        public string account { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public int gas_price { get; set; }
        public string body_hash { get; set; }
        public List<object> dependencies { get; set; }
        public string chain_name { get; set; }
    }
}
