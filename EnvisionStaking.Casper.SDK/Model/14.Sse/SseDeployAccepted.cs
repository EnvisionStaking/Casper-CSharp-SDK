using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Sse
{
    public class SseDeployAccepted
    {
        public DeployAccepted DeployAccepted { get; set; }
    }

    public class DeployAccepted
    {
        public string hash { get; set; }
        public DeployAcceptedHeader header { get; set; }
        public Payment payment { get; set; }
        public Session session { get; set; }
        public List<Approval> approvals { get; set; }
    }
    public class DeployAcceptedHeader
    {
        public string account { get; set; }
        public DateTime timestamp { get; set; }
        public string ttl { get; set; }
        public int gas_price { get; set; }
        public string body_hash { get; set; }
        public List<object> dependencies { get; set; }
        public string chain_name { get; set; }
    }

    public class ModuleBytes
    {
        public string module_bytes { get; set; }
        public List<List<object>> args { get; set; }
    }

    public class Payment
    {
        public ModuleBytes ModuleBytes { get; set; }
    }

    public class Transfer
    {
        public List<List<object>> args { get; set; }
    }

    public class Session
    {
        public Transfer Transfer { get; set; }
    }

    public class Approval
    {
        public string signer { get; set; }
        public string signature { get; set; }
    }
}
