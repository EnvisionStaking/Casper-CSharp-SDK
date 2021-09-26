using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.IsNotNull(result.result.deploy);
        }
        //[TestMethod]
        //public void MakeDeploy()
        //{
        //    //CasperClient casperClient = new CasperClient(rpcUrl);
        //    //var result = casperClient.RpcService.GetStateRootHash();

        //    //PutDeployParameters deploy = new PutDeployParameters();

        //    //deploy.hash = "bce3326a8bc2104e0acafde7f7bb154aa258265e563fb37b3386220942bdb368";

        //    //deploy.header.account = "019b11b42f55380e671278e58352b9b9e0babc454e9222dd435e820163649b7e8c";
        //    //deploy.header.timestamp = DateTime.Now;
        //    //deploy.header.ttl = "30m";
        //    //deploy.header.gas_price = 1;
        //    //deploy.header.body_hash = "418c521b564a606b0de4b5bfc572c0b93e4d7e6d1a20abb5d4d957d239dd9d9b";
        //    //deploy.header.dependencies = new List<string>();
        //    //deploy.header.chain_name = "casper";

        //    //deploy.approvals.Add(new Approval()
        //    //{
        //    //    signature = "011f89649c9c2208d154acb719a27b521c636ec7c164051afdf84a088eddc0ad8b404efd63773ab8e5b4443083c431885d7b7f367a503f8e757040d407f3560f08",
        //    //    signer = "019b11b42f55380e671278e58352b9b9e0babc454e9222dd435e820163649b7e8c"
        //    //});

        //    //deploy.session = new Session()
        //    //{
        //    //    Transfer = new DeployTransfer()
        //    //    {
        //    //        args = 
        //    //    }
        //    //}
        //    ////deploy.payment = new Payment()
        //    ////{
        //    ////    ModuleBytes = new ModuleBytes()
        //    ////    {
        //    ////        module_bytes = "";
        //    ////    }
        //    ////}

        //    //Assert.IsNotNull(deploy);
        //    //Assert.IsTrue(result.result.state_root_hash.Length > 1, "State Root Hash is empty");
        //}
    }
}
