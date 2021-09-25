using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Account
    {
        public string account_hash { get; set; }
        public List<object> named_keys { get; set; }
        public string main_purse { get; set; }
        public List<AssociatedKey> associated_keys { get; set; }
        public ActionThresholds action_thresholds { get; set; }
    }
}
