using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Change
    {
        public string public_key { get; set; }
        public List<StatusChange> status_changes { get; set; }
    }
}
