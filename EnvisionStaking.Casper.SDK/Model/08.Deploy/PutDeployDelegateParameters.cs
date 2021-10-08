using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployDelegateParameters
    {
        public PutDeployDelegate deploy { get; set; }
    }
    public class PutDeployDelegate
    {
        public List<Approval> approvals { get; set; }
        public string hash { get; set; }
        public PutDeployHeader header { get; set; }
        public PutDeployPayment payment { get; set; }
        public PutDeploySessionDelegate session { get; set; }
    }  

    public class PutDeploySessionDelegate
    {
        public DeployDelegate StoredContractByHash { get; set; }
    }
}