using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class HashServiceTest
    {
        string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";

        [TestMethod]
        public void GetAccountHash()
        {
            string publicKey = "01c4328cde0ce19e18e8bf61cb0f62af889b928a1b958ce69c401e21b07fb7acd6";
            string accountHash = "0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.HashService.GetAccountHash(publicKey);

            Assert.AreEqual(accountHash, result, true);
        }
    }
}
