using EnvisionStaking.Casper.SDK.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AccountInfo
{
    public class AccountInfoResult : Base.Result
    {
        public ResultBody result { get; set; }
    }
    public class ResultBody
    {
        public string api_version { get; set; }
        public Account account { get; set; }
        public string merkle_proof { get; set; }
    }
}
