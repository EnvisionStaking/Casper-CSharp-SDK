using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployInfo
    {
        public string deploy_hash { get; set; }
        public List<string> transfers { get; set; }
        public string from { get; set; }
        public string source { get; set; }
        public string gas { get; set; }
    }
}
