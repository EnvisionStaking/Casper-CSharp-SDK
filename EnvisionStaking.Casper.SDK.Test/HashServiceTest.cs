using EnvisionStaking.Casper.SDK.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class HashServiceTest
    {
        string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";

        [TestMethod]
        public void GetAccountHashEd25519()
        {
            string publicKey = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";
            string accountHash = "0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.HashService.GetAccountHash(publicKey);

            Assert.AreEqual(accountHash, result, true);
        }
        [TestMethod]
        public void GetAccountHashSec256K1()
        {
            string publicKey = "0203a9cd2472eeedb7081dd87ecae04d8fe1cedbf5e6a9fcb158ad966d94c63d2c6d";
            string accountHash = "23578762b1d8aa90871a306cd84e41090535dde69d2d04e12df530213d5c644c";
            
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.HashService.GetAccountHash(publicKey);

            Assert.AreEqual(accountHash, result, true);
        }

        [TestMethod]
        public void GetHashToHex()
        {
            string message = "Hello World";
            string hashedMessage = "1dc01772ee0171f5f614c673e3c7fa1107a8cf727bdf5a6dadb379e93c0d1d00";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.HashService.GetHashToHexFixedSize(Encoding.UTF8.GetBytes(message), 32);

            Assert.AreEqual(hashedMessage, result, true);
        }

        [TestMethod]
        public void GetHashToBinary()
        {
            string message = "Hello World";
            string hashedMessage = "1dc01772ee0171f5f614c673e3c7fa1107a8cf727bdf5a6dadb379e93c0d1d00";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.HashService.GetHashToBinaryFixedSize(Encoding.UTF8.GetBytes(message), 32);

            var resultInHex = ByteUtil.ByteArrayToHex(result);

            Assert.AreEqual(hashedMessage, resultInHex, true);
        }
    }
}
