using EnvisionStaking.Casper.SDK.Model;
using EnvisionStaking.Casper.SDK.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Model.DeployObject
{
    public class PutDeployStoredVersionedContractByHashParameters : DeployBase
    {
        public PutDeployStoredVersionedContractByHash deploy { get; set; }
    }
    public class PutDeployStoredVersionedContractByHash
    {      
        public DeploySessionStoredVersionedContractByHash session { get; set; }
    }  
    
}