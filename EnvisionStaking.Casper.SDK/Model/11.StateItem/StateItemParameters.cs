using EnvisionStaking.Casper.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.StateItem
{
    public class StateItemParameters
    {
        public string key { get; set; }
        public string state_root_hash { get; set; }
    }
}
