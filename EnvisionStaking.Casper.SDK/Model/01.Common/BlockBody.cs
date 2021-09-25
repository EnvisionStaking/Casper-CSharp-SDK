using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class BlockBody
    {
        public string proposer { get; set; }
        public List<object> deploy_hashes { get; set; }
        public List<string> transfer_hashes { get; set; }
    }
}
