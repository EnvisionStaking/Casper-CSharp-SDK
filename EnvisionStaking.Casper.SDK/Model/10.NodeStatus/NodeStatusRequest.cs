using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.NodeStatus
{
    public class RPCSchemaRequest : Base.Request
    {
        public RPCSchemaRequest()
        {
            this.method = "info_get_status";
        }        
    }
}
