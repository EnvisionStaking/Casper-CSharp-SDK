using EnvisionStaking.Casper.SDK.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.BlockTransfers
{
    public class BlockTransfersResult : Base.Result
    {
        public ResultBody result { get; set; }

        public class ResultBody
        {
            public string api_version { get; set; }
            public string block_hash { get; set; }
            public List<Transfer> transfers { get; set; }
        }      
    }
}
