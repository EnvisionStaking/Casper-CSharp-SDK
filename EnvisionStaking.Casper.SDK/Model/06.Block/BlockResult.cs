using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Block
{
    public class BlockResult : Base.Result
    {
        public ResultBody result { get; set; }

        public class ResultBody
        {
            public string api_version { get; set; }
            public Common.Block block { get; set; }
        }  

    }
}
