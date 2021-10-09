using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class Session
    {
        public DeployTransfer Transfer { get; set; }
        public DeployStoredContractByHash StoredContractByHash { get; set; }
        public DeployStoredContractByName StoredContractByName { get; set; }
        public DeployStoredVersionedContractByHash DeployStoredVersionedContractByHash { get; set; }
        public DeployStoredVersionedContractByName DeployStoredVersionedContractByName { get; set; }
    }
}
