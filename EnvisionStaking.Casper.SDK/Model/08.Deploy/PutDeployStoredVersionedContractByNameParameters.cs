using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredVersionedContractByNameParameters : DeployBase
    {
        public PutDeployStoredVersionedContractByName deploy { get; set; }
    }
    public class PutDeployStoredVersionedContractByName
    {      
        public DeploySessionStoredVersionedContractByName session { get; set; }
    }  
    
}