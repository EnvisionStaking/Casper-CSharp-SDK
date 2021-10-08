using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredContractByNameRequest : Base.Request
    {
        public PutDeployStoredContractByNameRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployStoredContractByNameParameters();
        }

        [JsonProperty("params")]
        public PutDeployStoredContractByNameParameters Parameters { get; set; }
    }
}