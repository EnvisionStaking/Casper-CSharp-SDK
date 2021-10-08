using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredContractByHashParameters
    {
        public PutDeployStoredContractByHash deploy { get; set; }
    }
    public class PutDeployStoredContractByHash : DeployBase
    {      
        public DeploySessionStoredContractByHash session { get; set; }
    }  
    
}