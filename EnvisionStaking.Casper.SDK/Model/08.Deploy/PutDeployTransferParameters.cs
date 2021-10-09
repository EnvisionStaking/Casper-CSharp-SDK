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
    public class PutDeployTransfer
    {
        public List<Approval> approvals { get; set; }
        public string hash { get; set; }
        public DeployHeader header { get; set; }
        public DeployPayment payment { get; set; }
        public DeploySessionTransfer session { get; set; }
    }
}