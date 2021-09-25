using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AccountBalance
{
    public class AccountBalanceResult : Base.Result
    {
        public ResultBody result { get; set; }
    }
    public class ResultBody
    {
        public string api_version { get; set; }
        public string balance_value { get; set; }
        public string merkle_proof { get; set; }
    }
}
