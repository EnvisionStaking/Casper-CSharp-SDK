using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class ModuleBytes
    {
        public string module_bytes { get; set; }
        public List<List<object>> args { get; set; }
    }
}
