using EnvisionStaking.Casper.SDK.Enums;
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
        string fromAccountKey01 = "01da19d95aae08da9df0c3a7ba8fbb368af4fb99e7f522b6471963473295955031";
        string fromAccountKey02 = "0203a9cd2472eeedb7081dd87ecae04d8fe1cedbf5e6a9fcb158ad966d94c63d2c6d";
        string toAccountKey = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";       

        [TestMethod]
        public void GetDeploy()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetDeploy("bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368");

            var test = result.result.deploy.payment.ModuleBytes.argsObject;

            Assert.IsNotNull(result.result.deploy);
        }

        #region Transfer
        [TestMethod]
        public void TransferEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);

            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Transfer(0, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        [TestMethod]
        public void TransferSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Transfer(0, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        [TestMethod]
        public void TransferToJsonEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.TransferToJson(2.5, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void TransferToJsonSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.TransferToJson(2.5, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

            Assert.IsNotNull(makeDeployResult);
        }
        #endregion

        #region Delegate\Undelegate

        [TestMethod]
        public void DelegateEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Delegate(0, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        public void UnelegateEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Undelegate(0, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        [TestMethod]
        public void DelegateToJsonEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.DelegateToJson(0, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void UndelegateToJsonEd25519()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.UndelegateToJson(0, fromAccountKey01, toAccountKey, 1, @"keys\Ed25519_Test_public_key.pem", @"keys\Ed25519_Test_secret_key.pem", SignAlgorithmEnum.ed25519);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void DelegateSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Delegate(0, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        [TestMethod]
        public void UndelegateSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            PutDeployResult putDeployResult = null; ;
            try
            {
                putDeployResult = casperClient.DeployService.Undelegate(0, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

                Assert.IsNotNull(putDeployResult.error);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("invalid deploy: insufficient transfer amount"));
            }
        }

        [TestMethod]
        public void DelegateToJsonSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.DelegateToJson(0, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

            Assert.IsNotNull(makeDeployResult);
        }

        [TestMethod]
        public void UndelegateToJsonSecp256k1()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var makeDeployResult = casperClient.DeployService.UndelegateToJson(0, fromAccountKey02, toAccountKey, 1, @"keys\Secp256k1_Test_public_key.pem", @"keys\Secp256k1_Test_secret_key.pem", SignAlgorithmEnum.secp256k1);

            Assert.IsNotNull(makeDeployResult);
        }
        #endregion
    }
}
