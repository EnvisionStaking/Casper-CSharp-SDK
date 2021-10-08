using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredContractByNameParameters : DeployBase
    {
        public PutDeployStoredContractByName deploy { get; set; }
    }
    public class PutDeployStoredContractByName
    {      
        public DeploySessionStoredContractByName session { get; set; }
    }  
    
}