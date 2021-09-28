using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployParameters
    {
        public PutDeployDeploy deploy { get; set; }
    }
    public class PutDeployDeploy
    {       
        public string hash { get; set; }
        public PutDeployHeader header { get; set; }
        public List<Approval> approvals { get; set; }
        public PutDeployPayment payment { get; set; }
        public PutDeployTransfer transfer { get; set; }
    }
   
    public class PutDeployHeader
    {
        public string account { get; set; }
        public string body_hash { get; set; }
        public string chain_name { get; set; }
        public long gas_price { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public List<string> dependencies { get; set; }

    }

    public class PutDeployPayment
    {
        public ModuleBytes ModuleBytes { get; set; }     
    }

    public class PutDeployTransfer
    {
        public ModuleBytes ModuleBytes { get; set; }
    }
}