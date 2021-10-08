using EnvisionStaking.Casper.SDK.Model.DeployObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{
    public class DeployBase
    {
        public List<Approval> approvals { get; set; }
        public string hash { get; set; }
        public DeployHeader header { get; set; }
        public DeployPayment payment { get; set; }
    }
}
