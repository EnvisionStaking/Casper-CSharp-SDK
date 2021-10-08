using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployTransferParameters 
    {
        public PutDeployTransfer deploy { get; set; }
    }
    public class PutDeployTransfer : DeployBase
    {
        public DeploySessionTransfer session { get; set; }
    }
}