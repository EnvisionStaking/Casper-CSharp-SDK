using EnvisionStaking.Casper.SDK.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployResult : Base.Result    {
        public PutDeployResultBody result { get; set; }
        
    }
    public class PutDeployResultBody
    {
        public string api_version { get; set; }
        public string deploy_hash { get; set; }
    }

   

   









    





   

   
   
}
