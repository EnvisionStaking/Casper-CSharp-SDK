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
        public string hash { get; set; }
        public PutDeployHeaderParameter header { get; set; }
        public List<Approval> approvals { get; set; }
        public PutDeployTransfer transfer { get; set; }
    }

    public class PutDeployHeaderParameter
    {
        public string account { get; set; }
        public string body_hash { get; set; }
        public string chain_name { get; set; }
        public long gas_price { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public List<string> dependencies { get; set; }

    }

    public class PutDeployTransfer
    {
        public string account { get; set; }
        public string body_hash { get; set; }
        public string chain_name { get; set; }
        public long gas_price { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public List<string> dependencies { get; set; }

    }
}