using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AccountInfo
{
    class AccountInfoRequest:Base.Request
    {
        public AccountInfoRequest()
        {
            this.method = "state_get_account_info";
            this.Parameters = new AccountInfoParameters();
        }

        public AccountInfoRequest(string publicKey)
        {
            this.method = "state_get_account_info";
            this.Parameters = new AccountInfoParameters() { public_key = publicKey };
        }

        [JsonProperty("params")]
        public AccountInfoParameters Parameters { get; set; }
    }
}