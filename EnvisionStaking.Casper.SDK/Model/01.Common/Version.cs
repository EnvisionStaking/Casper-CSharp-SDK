using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Version
    {
        public int protocol_version_major { get; set; }
        public int contract_version { get; set; }
        public string contract_hash { get; set; }
    }
}
