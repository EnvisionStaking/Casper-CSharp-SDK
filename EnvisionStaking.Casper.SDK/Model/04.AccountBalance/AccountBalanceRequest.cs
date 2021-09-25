using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AccountBalance
{
    class AccountBalanceRequest : Base.Request
    {
        public AccountBalanceRequest()
        {
            this.method = "state_get_balance";
            this.Parameters = new AccountBalanceParameters();
        }

        public AccountBalanceRequest(string purseUref, string stateRootHash)
        {
            this.method = "state_get_balance";
            this.Parameters = new AccountBalanceParameters() {purse_uref = purseUref, state_root_hash = stateRootHash};
        }

        [JsonProperty("params")]
        public AccountBalanceParameters Parameters { get; set; }
    }
}

