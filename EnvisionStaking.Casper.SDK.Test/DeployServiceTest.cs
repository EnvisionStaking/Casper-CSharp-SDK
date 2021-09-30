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
        string metricsUrl = "http://40.69.22.98:8888/metrics";
        string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";

        [TestMethod]
        public void GetDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetDeploy("bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368");

            var test = result.result.deploy.payment.ModuleBytes.argsObject;

            Assert.IsNotNull(result.result.deploy);
        }

        [TestMethod]
        public void PutDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.PutDeploy(50, "01ddf755862dcde8de3e7ff13d9c42481d39e422cc461518bb12b8fb0c9366c79c", 1);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void MakeDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.MakeDeploy(50, "01ddf755862dcde8de3e7ff13d9c42481d39e422cc461518bb12b8fb0c9366c79c", 1);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void MakeDeployToJson()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.MakeDeployToJson(50, "01ddf755862dcde8de3e7ff13d9c42481d39e422cc461518bb12b8fb0c9366c79c", 1);

            Assert.IsNotNull(makeDeployResult);
        }
    }
}
