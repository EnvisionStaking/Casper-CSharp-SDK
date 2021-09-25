using EnvisionStaking.Casper.SDK.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Era
{
    public class EraInfoResult : Base.Result
    {
        public ResultBody result { get; set; }

        public class ResultBody
        {
            public string api_version { get; set; }
            public EraSummary era_summary { get; set; }
        }
    }
}
