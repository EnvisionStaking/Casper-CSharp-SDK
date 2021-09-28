using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployRequest : Base.Request
    {
        public PutDeployRequest()
        {
            this.method = "account_put_deploy";
            this.Parameters = new PutDeployParameters();
        }

        public PutDeployRequest(Deploy deployParam)
        {
            this.method = "account_put_deploy";
            //this.Parameters = new PutDeployParameters() { deploy = deployParam };
        }

        [JsonProperty("params")]
        public PutDeployParameters Parameters { get; set; }
    }
}