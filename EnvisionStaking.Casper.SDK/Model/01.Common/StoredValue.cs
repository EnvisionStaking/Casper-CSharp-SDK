using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class StoredValue
    {
        public DeployInfo DeployInfo { get; set; }
        public Account Account { get; set; }
        public CLValue CLValue { get; set; }
        public string ContractWasm { get; set; }
        public Transfer Transfer { get; set; }
        public Contract Contract { get; set; }
        public ContractPackage ContractPackage { get; set; }
        public JsonBid Bid { get; set; }
        public List<Withdraw> Withdraw { get; set; }
        public EraInfo EraInfo { get; set; }
    }
}
