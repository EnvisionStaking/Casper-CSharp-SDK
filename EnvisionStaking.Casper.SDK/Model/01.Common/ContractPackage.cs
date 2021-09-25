using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class ContractPackage
    {
        public string access_key { get; set; }
        public List<Version> versions { get; set; }
        public List<object> disabled_versions { get; set; }
        public List<object> groups { get; set; }
    }
}
