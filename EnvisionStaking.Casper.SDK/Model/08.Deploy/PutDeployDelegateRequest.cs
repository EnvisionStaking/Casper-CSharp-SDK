using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployDelegateRequest : Base.Request
    {
        public PutDeployDelegateRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployDelegateParameters();
        }

        public PutDeployDelegateRequest(Deploy deployParam)
        {
            this.method = "account_put_deploy";
        }

        [JsonProperty("params")]
        public PutDeployDelegateParameters Parameters { get; set; }
    }
}