using EnvisionStaking.Casper.SDK.Model.Common;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class DeployServiceTest
    {
        string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";
        string fromAccountKey = "01d30f6a241199e68217cb05abcefc7c8267c5226b8e644f1f8d0a79b87ed04f07";
        string toAccountKey = "01d30f6a241199e68217cb05abcefc7c8267c5226b8e644f1f8d0a79b87ed04f07";
        //string toAccountKey = "020228782ebc6dc9fc2fd67f08bce741bdd4892ff0c616811bc0cfeff5daf5476bd1";
        [TestMethod]
        public void GetDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetDeploy("bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368");

            var test = result.result.deploy.payment.ModuleBytes.argsObject;

            Assert.IsNotNull(result.result.deploy);
        }

        //[TestMethod]
        public void PutDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.PutDeploy(25, fromAccountKey, toAccountKey, 1, @"keys\public_key.pem", @"keys\secret_key.pem");

            Assert.IsNotNull(makeDeployResult);
        }

        //[TestMethod]
        public void MakeDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.MakeDeploy(25, fromAccountKey, toAccountKey, 1, @"keys\public_key.pem", @"keys\secret_key.pem");

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void MakeDeployToJson()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.MakeDeployToJson(25, fromAccountKey, toAccountKey, 1, @"keys\public_key.pem", @"keys\secret_key.pem");

            Assert.IsNotNull(makeDeployResult);
        }
    }
}
