using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.RpcSchema
{
    public class RpcSchemaRequest : Base.Request
    {
        public RpcSchemaRequest()
        {
            this.method = "rpc.discover";
        }        
    }
}
