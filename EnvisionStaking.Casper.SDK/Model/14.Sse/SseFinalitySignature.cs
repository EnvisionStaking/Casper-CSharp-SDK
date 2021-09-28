using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Sse
{
    public class SseFinalitySignature
    {        public FinalitySignature FinalitySignature { get; set; }
    }
    public class FinalitySignature
    {
        public string block_hash { get; set; }
        public int era_id { get; set; }
        public string signature { get; set; }
        public string public_key { get; set; }
    }

   
}
