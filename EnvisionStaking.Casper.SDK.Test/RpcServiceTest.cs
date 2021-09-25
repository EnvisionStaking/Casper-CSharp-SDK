using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class RpcServiceTest
    {
        string rpcUrl = "https://node-clarity-mainnet.make.services/rpc";
        string metricsUrl = "http://40.69.22.98:8888/metrics";
        string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";
        
        [TestMethod]
        public void GetStateRootHash()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateRootHash();

            Assert.IsNotNull(result.result.state_root_hash);
            Assert.IsTrue(result.result.state_root_hash.Length > 1, "State Root Hash is empty");
        }
    }
}
