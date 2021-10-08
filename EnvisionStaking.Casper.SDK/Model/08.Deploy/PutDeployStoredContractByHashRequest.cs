using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredContractByHashRequest : Base.Request
    {
        public PutDeployStoredContractByHashRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployStoredContractByHashParameters();
        }      

        [JsonProperty("params")]
        public PutDeployStoredContractByHashParameters Parameters { get; set; }
    }
}