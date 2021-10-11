using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class DeployRequest : Base.Request
    {
        public DeployRequest()
        {
            this.method = "info_get_deploy";
            this.Parameters = new DeployParameters();
        }

        public DeployRequest(string deployHash)
        {
            this.method = "info_get_deploy";
            this.Parameters = new DeployParameters() { deploy_hash = deployHash };
        }

        [JsonProperty("params")]
        public DeployParameters Parameters { get; set; }
    }
}