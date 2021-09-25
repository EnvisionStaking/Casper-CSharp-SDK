using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.NodePeers
{
    public class NodePeersRequest : Base.Request
    {
        public NodePeersRequest()
        {
            this.method = "info_get_peers";
        }       
    }
}