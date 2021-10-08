using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredVersionedContractByHashRequest : Base.Request
    {
        public PutDeployStoredVersionedContractByHashRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployStoredVersionedContractByHashParameters();
        }

        [JsonProperty("params")]
        public PutDeployStoredVersionedContractByHashParameters Parameters { get; set; }
    }
}