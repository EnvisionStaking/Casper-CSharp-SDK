using EnvisionStaking.Casper.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.AccountBalance
{
    public class AccountBalanceParameters
    {
        public string state_root_hash { get; set; }

        public string purse_uref { get; set; }
    }
}