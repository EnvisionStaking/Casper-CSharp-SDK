using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class RpcServiceTest
    {
        string rpcUrl = "http://54.183.43.215:7777/rpc";
        string metricsUrl = "http://54.183.43.215:8888/metrics";
        string accountKey = "0202ba37a693fb6494b3c42a65f07a6123dd125d8bf8a16e10ec7b95b826b151230c";
        
        [TestMethod]
        public void GetStateRootHash()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateRootHash();

            Assert.IsNotNull(result.result.state_root_hash);
            Assert.IsTrue(result.result.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetStateRootHashByBlockHash()
        {
            string blockHash = "eae069dcc4888da536dfc3f33509025a936d14bf09c012cc8073ee0d91e3ce84";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateRootHashByBlockHash(blockHash);

            Assert.IsNotNull(result.result.state_root_hash);
            Assert.IsTrue(result.result.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetStateRootHashByHeight()
        {
            string blockHeight = "223873";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateRootHashByHeight(blockHeight);

            Assert.IsNotNull(result.result.state_root_hash);
            Assert.IsTrue(result.result.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetAccountInfo()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetAccountInfo(accountKey);

            Assert.IsNotNull(result.result.account.account_hash);
            Assert.IsTrue(result.result.account.account_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetAccountBalance()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetAccountBalance(accountKey);

            Assert.IsNotNull(result.result.balance_value);
            Assert.IsTrue(!string.IsNullOrEmpty(result.result.balance_value), "Balance has no value");
        }

        [TestMethod]
        public void GetAccountHash()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetAccountHash(accountKey);

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result), "Hash has no value");
        }

        [TestMethod]
        public void GetAccountMainPurse()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetAccountMainPurse(accountKey);

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result), "Main Purse has no value");
        }

        [TestMethod]
        public void GetAuctionInfo()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetAuctionInfo();

            Assert.IsNotNull(result.result.auction_state.state_root_hash);
            Assert.IsTrue(result.result.auction_state.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetBlockLast()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockLast();

            Assert.IsNotNull(result.result.block);
            Assert.IsTrue(result.result.block.header.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetBlockByHeight()
        {
            string blockHeight = "222938";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockByHeight(blockHeight);

            Assert.IsNotNull(result.result.block);
            Assert.IsTrue(result.result.block.header.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetBlockByHash()
        {
            string blockHash = "3566b6cdc30d0d9871cc6b208a7b17acefa1e22107800a098c4cd88e82a6fee2";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockByHash(blockHash);

            Assert.IsNotNull(result.result.block);
            Assert.IsTrue(result.result.block.header.state_root_hash.Length > 1, "State Root Hash is empty");
        }

        [TestMethod]
        public void GetBlockTransfersLast()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockTransfersLast();

            Assert.IsNotNull(result.result.block_hash);
            Assert.IsTrue(!string.IsNullOrEmpty(result.result.block_hash), "Block Hash is empty");
        }

        [TestMethod]
        public void GetBlockTransfersByHeight()
        {
            string blockHeight = "223760";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockTransfersByHeight(blockHeight);

            Assert.IsNotNull(result.result.block_hash);
            Assert.IsTrue(!string.IsNullOrEmpty(result.result.block_hash), "Block Hash is empty");
        }

        [TestMethod]
        public void GetBlockTransfersByHash()
        {
            string blockHash = "3566b6cdc30d0d9871cc6b208a7b17acefa1e22107800a098c4cd88e82a6fee2";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetBlockTransfersByHash(blockHash);

            Assert.IsNotNull(result.result.block_hash);
            Assert.IsTrue(!string.IsNullOrEmpty(result.result.block_hash), "Block Hash is empty");
        }

        [TestMethod]
        public void GetDeploy()
        {
            string deployHash = "bc4b4fa65eb906e6d4e383adacb8e8ba14b768029a535b5b1381b2b47847c32e";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetDeploy(deployHash);

            Assert.IsNotNull(result.result.deploy);
            Assert.IsTrue(!string.IsNullOrEmpty(result.result.deploy.header.account), "Account is empty");
        }

        [TestMethod]
        public void GetEraInfoLast()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetEraInfoLast();

            Assert.IsNotNull(result.result);
            Assert.IsNotNull(result.result.era_summary);
        }

        [TestMethod]
        public void GetEraInfoByHeight()
        {
            string blockHeight = "223692";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetEraInfoByHeight(blockHeight);

            Assert.IsNotNull(result.result);
            Assert.IsNotNull(result.result.era_summary);
        }

        [TestMethod]
        public void GetEraInfoByHash()
        {
            string blockHash = "d0b3f52c02f8dfee84bdc5cb2e00d803d2dc36f3ed325cf556412baef6ead722";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetEraInfoByHash(blockHash);

            Assert.IsNotNull(result.result);
            Assert.IsNotNull(result.result.era_summary);
        }

        [TestMethod]
        public void GetNodeMetrics()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetNodeMetrics(metricsUrl);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNodeStatus()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetNodeStatus();

            Assert.IsNotNull(result.result);
            Assert.IsNotNull(result.result.last_added_block_info);
        }

        [TestMethod]
        public void GetRPCShema()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetRPCShema();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNodePeers()
        {
            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetNodePeers();

            Assert.IsNotNull(result.result);
            Assert.IsTrue(result.result.peers.Capacity>0,"Node Peers are empty");
        }

        [TestMethod]
        public void GetStateItemAccount()
        {
            string hash = "account-hash-18afc5167d3e815c80cd0742f615dddfebee2a2f5e8285015b23b8d134292a5c";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.Account);
        }

        [TestMethod]
        public void GetStateItemDeploy()
        {
            string hash = "deploy-1498ee265159d1969ef5c404048358fbac7354909c03871d97011558eaf0a121";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.DeployInfo);
        }

        [TestMethod]
        public void GetStateItemCLVAlue()
        {
            string hash = "uref-fdb1ba9c73573817ff05674e8d488a2eea95fd8d22942c250035e1063c899fa8-007";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.CLValue);
        }

        [TestMethod]
        public void GetStateItemTransfer()
        {
            string hash = "transfer-8083a53dd4d911eabefb83004eab3537aee8d8b9a340dced9826f1397b3b0bee";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.Transfer);
        }

        [TestMethod]
        public void GetStateItemContract()
        {
            string hash = "hash-7cc1b1db4e08bbfe7bacf8e1ad828a5d9bcccbb33e55d322808c3a88da53213a";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.Contract);
        }

        [TestMethod]
        public void GetStateItemContractPackage()
        {
            string hash = "hash-4475016098705466254edd18d267a9dad43e341d4dafadb507d0fe3cf2d4a74b";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.ContractPackage);
        }

        [TestMethod]
        public void GetStateItemContractWasm()
        {
            string hash = "hash-41c6f5bad412de7e16af7943b0c751f0dc9152a337c8b024313057dd8d707f99";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.ContractWasm);
        }

        [TestMethod]
        public void GetStateItemBid()
        {
            string hash = "bid-0f57db4471e7ace70bc45c23ee87d287d0eabfe1090b813e3e7cb73657efce8e";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.Bid);
        }

        [TestMethod]
        public void GetStateItemWithdraw()
        {
            string hash = "withdraw-6e999553ae78baf7799c6a10136888509d3f54cd896b0fe67376f45474180337";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.Withdraw);
        }

        [TestMethod]
        public void GetStateItemEraInfo()
        {
            string hash = "6e999553ae78baf7799c6a10136888509d3f54cd896b0fe67376f45474180337";

            CasperClient casperClient = new CasperClient(rpcUrl);
            var result = casperClient.RpcService.GetStateItem(hash);

            Assert.IsNotNull(result.result.stored_value.EraInfo);
        }
    }
}