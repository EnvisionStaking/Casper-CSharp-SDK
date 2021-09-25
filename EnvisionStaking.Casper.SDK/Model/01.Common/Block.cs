using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Block
    {
        public string hash { get; set; }
        public BlockHeader header { get; set; }
        public BlockBody body { get; set; }
        public List<Proof> proofs { get; set; }
    }
}
