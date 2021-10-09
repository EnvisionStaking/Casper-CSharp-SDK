using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class RpcServiceAsyncTest
    {
        string rpcUrl = "http://40.69.22.98:7777/rpc";

        [TestMethod]
        public async Task GetNextBlockAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = await casperClient.RpcService.GetNextBlockAsync();

            Assert.IsNotNull(result.result.block);
        }

        [TestMethod]
        public async Task AwaitNBlockAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = await casperClient.RpcService.AwaitNBlockAsync(1);

            Assert.IsNotNull(result.result.block);
        }

        [TestMethod]
        public async Task AwaitUntilDeployCompletedAsync()
        {
            var deployHash = "b96bc0f44dd79c6793d16c52e53760004367c8400de0eb17e46edda75289a856";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var deployResult = await casperClient.RpcService.AwaitUntilDeployCompletedAsync(deployHash);
            
            Assert.IsNotNull(deployResult.result.execution_results);
            Assert.IsTrue(deployResult.result.execution_results.Count>0);
        }

        [TestMethod]
        public async Task AwaitUntilNBlockAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var currentBlock = casperClient.RpcService.GetBlockLast();
            var result = await casperClient.RpcService.AwaitUntilNBlockAsync(currentBlock.result.block.header.height+1);

            Assert.IsNotNull(result.result.block);
        }

        //[TestMethod]
        public async Task GetNextEraAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = await casperClient.RpcService.GetNextEraAsync();

            Assert.IsNotNull(result);
            Assert.IsTrue(result>0);
        }

        //[TestMethod]
        public async Task AwaitNEraAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = await casperClient.RpcService.AwaitNEraAsync(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }

        //[TestMethod]
        public async Task AwaitUntilNEraAsync()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var currentBlock = casperClient.RpcService.GetBlockLast();
            var result = await casperClient.RpcService.AwaitUntilNEraAsync(currentBlock.result.block.header.era_id + 1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }
    }
}
        