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
        public string hash { get; set; }
        public PutDeployHeader header { get; set; }
        public PutDeployPayment payment { get; set; }
        public PutDeploySessionTransfer session { get; set; }
        public List<Approval> approvals { get; set; }
    }
    [Serializable]
    public class PutDeployHeader
    {
        public string account { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public long gas_price { get; set; }
        public string body_hash { get; set; }
        public List<string> dependencies { get; set; }
        public string chain_name { get; set; }
    }
    [Serializable]
    public class PutDeployPayment
    {
        public DeployModuleBytes ModuleBytes { get; set; }     
    }

    public class PutDeploySessionTransfer
    {
        public DeployTransfer Transfer { get; set; }
    }
}