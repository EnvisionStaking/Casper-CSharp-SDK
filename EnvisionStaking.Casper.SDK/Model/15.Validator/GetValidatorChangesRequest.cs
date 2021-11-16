using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.NodePeers
{
    public class GetValidatorChangesRequest : Base.Request
    {
        public GetValidatorChangesRequest()
        {
            this.method = "info_get_validator_changes";
        }       
    }
}