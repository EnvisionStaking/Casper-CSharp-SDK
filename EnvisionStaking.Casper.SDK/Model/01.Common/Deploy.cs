using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.Common
{    public class Deploy
    {
        public string hash { get; set; }
        public DeployHeader header { get; set; }
        public Payment payment { get; set; }
        public Session session { get; set; }
        public List<Approval> approvals { get; set; }
    }
}
