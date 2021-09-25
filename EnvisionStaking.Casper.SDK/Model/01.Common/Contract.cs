using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Contract
    {
        public string contract_package_hash { get; set; }
        public string contract_wasm_hash { get; set; }
        public List<NamedKey> named_keys { get; set; }
        public List<EntryPoint> entry_points { get; set; }
        public string protocol_version { get; set; }
    }
}
