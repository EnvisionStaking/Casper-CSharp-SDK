using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Transfer
    {
        public string deploy_hash { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string amount { get; set; }
        public string gas { get; set; }
        public int? id { get; set; }
    }
}
