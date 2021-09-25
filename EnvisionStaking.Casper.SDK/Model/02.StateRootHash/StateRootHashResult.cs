using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.StateRootHash
{
    public class StateRootHashResult : Base.Result
    {
        public ResultBody result { get; set; }
    }

    public class ResultBody
    {
        public string api_version { get; set; }
        public string state_root_hash { get; set; }
    }
}
