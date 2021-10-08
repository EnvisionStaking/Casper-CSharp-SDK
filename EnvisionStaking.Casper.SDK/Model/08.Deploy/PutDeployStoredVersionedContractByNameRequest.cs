using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredVersionedContractByNameRequest : Base.Request
    {
        public PutDeployStoredVersionedContractByNameRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployStoredVersionedContractByNameParameters();
        }

        [JsonProperty("params")]
        public PutDeployStoredVersionedContractByNameParameters Parameters { get; set; }
    }
}