using EnvisionStaking.Casper.SDK.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class DeployResult : Base.Result    {
        public ResultBody result { get; set; }
        
    }
    public class ResultBody
    {
        public string api_version { get; set; }
        public Deploy deploy { get; set; }
        public List<ExecutionResultRoot> execution_results { get; set; }
    }

   

   









    





   

   
   
}
