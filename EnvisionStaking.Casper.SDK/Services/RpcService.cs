using EnvisionStaking.Casper.SDK.Model.AccountBalance;
using EnvisionStaking.Casper.SDK.Model.AccountInfo;
using EnvisionStaking.Casper.SDK.Model.AuctionInfo;
using EnvisionStaking.Casper.SDK.Model.Base;
using EnvisionStaking.Casper.SDK.Model.Block;
using EnvisionStaking.Casper.SDK.Model.BlockTransfers;
using EnvisionStaking.Casper.SDK.Model.DeployObject;
using EnvisionStaking.Casper.SDK.Model.Era;
using EnvisionStaking.Casper.SDK.Model.NodePeers;
using EnvisionStaking.Casper.SDK.Model.NodeStatus;
using EnvisionStaking.Casper.SDK.Model.StateItem;
using EnvisionStaking.Casper.SDK.Model.StateRootHash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Result = EnvisionStaking.Casper.SDK.Model.Base.Result;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class RpcService
    {
        private const int BLOCKDELAY = 5000;
        private const int ERADELAY = 60000;

        public RpcService(string rpcUrl, string jsonRpcVersion = "2.0", string jsonRpcId = "0")
        {
            JsonRpcVersion = jsonRpcVersion;
            RpCUrl = rpcUrl;
            JsonRpcId = jsonRpcId;
        }

        public string JsonRpcId { get; set; }
        public string JsonRpcVersion { get; set; }
        public string RpCUrl { get; set; }

        #region StateRootHash
        public StateRootHashResult GetStateRootHash()
        {

            StateRootHashRequest request = new StateRootHashRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }

        public StateRootHashResult GetStateRootHashByBlockHash(string hash)
        {
            StateRootHashRequest request = new StateRootHashRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }

        public StateRootHashResult GetStateRootHashByHeight(string height)
        {
            StateRootHashRequest request = new StateRootHashRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateRootHashRequest, StateRootHashResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Account
        public AccountInfoResult GetAccountInfo(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            return RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        public string GetAccountHash(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            AccountInfoResult accountInforResult = RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);

            return accountInforResult.result.account.account_hash;
        }
        public string GetAccountMainPurse(string key)
        {
            AccountInfoRequest request = new AccountInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.public_key = key; ;

            AccountInfoResult accountInforResult = RpcClient<AccountInfoRequest, AccountInfoResult>(RpCUrl, request, HttpMethod.Post);

            return accountInforResult.result.account.main_purse;
        }
        public AccountBalanceResult GetAccountBalance(string mainPurse, string stateRootHash)
        {
            AccountBalanceRequest request = new AccountBalanceRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;
            request.Parameters.purse_uref = mainPurse;
            request.Parameters.state_root_hash = stateRootHash;

            return RpcClient<AccountBalanceRequest, AccountBalanceResult>(RpCUrl, request, HttpMethod.Post);
        }
        public AccountBalanceResult GetAccountBalance(string key)
        {
            AccountInfoResult acountInfoResult = GetAccountInfo(key);
            StateRootHashResult stateRootHashResult = GetStateRootHash();
            return GetAccountBalance(acountInfoResult.result.account.main_purse, stateRootHashResult.result.state_root_hash);
        }
        #endregion

        #region Auction
        public AuctionInfoResult GetAuctionInfo()
        {
            AuctionInfoRequest request = new AuctionInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<AuctionInfoRequest, AuctionInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Block

        #region Synchronous Operations
        public BlockResult GetBlockLast()
        {
            BlockRequest request = new BlockRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }

        public BlockResult GetBlockByHash(string hash)
        {
            BlockRequest request = new BlockRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }

        public BlockResult GetBlockByHeight(string height)
        {
            BlockRequest request = new BlockRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockRequest, BlockResult>(RpCUrl, request, HttpMethod.Post);
        }

        public BlockTransfersResult GetBlockTransfersLast()
        {
            BlockTransfersRequest request = new BlockTransfersRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }

        public BlockTransfersResult GetBlockTransfersByHash(string hash)
        {
            BlockTransfersRequest request = new BlockTransfersRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }

        public BlockTransfersResult GetBlockTransfersByHeight(string height)
        {
            BlockTransfersRequest request = new BlockTransfersRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<BlockTransfersRequest, BlockTransfersResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Asynchronous Operations
        public async Task<BlockResult> GetNextBlockAsync()
        {
            var block = GetBlockLast();
            var currentBlockHeight = block.result.block.header.height;

            while (block.result.block.header.height == currentBlockHeight)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }

        public async Task<BlockResult> AwaitNBlockAsync(int nBlock = 1)
        {
            if (nBlock < 1)
            {
                throw new ArgumentOutOfRangeException("The number of Blocks to wait should be equal or more than one");
            }

            var block = GetBlockLast();
            var nextNBlock = block.result.block.header.height + nBlock;

            while (block.result.block.header.height < nextNBlock)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }

        public async Task<BlockResult> AwaitUntilNBlockAsync(int untilNBlockHeight)
        {
            var block = GetBlockLast();

            if (block.result.block.header.height >= untilNBlockHeight)
            {
                throw new ArgumentOutOfRangeException($"The Block Height selected should be bigger than current block height ({block.result.block.header.height})");
            }

            while (block.result.block.header.height < untilNBlockHeight)
            {
                await Task.Delay(BLOCKDELAY);
                block = GetBlockLast();
            }

            return block;
        }
        #endregion

        #endregion

        #region Deploy
        public DeployResult GetDeploy(string deployHash)
        {
            DeployRequest request = new DeployRequest(deployHash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<DeployRequest, DeployResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Era

        #region Synchronous Services
        public EraInfoResult GetEraInfoLast()
        {
            EraInfoRequest request = new EraInfoRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }

        public EraInfoResult GetEraInfoByHash(string hash)
        {
            EraInfoRequest request = new EraInfoRequest(hash);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }

        public EraInfoResult GetEraInfoByHeight(string height)
        {
            EraInfoRequest request = new EraInfoRequest(height);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<EraInfoRequest, EraInfoResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region Asynchronous Services

        public async Task<int> GetNextEraAsync()
        {
            var block = GetBlockLast();
            var currentBlockEraId = block.result.block.header.era_id;

            while (block.result.block.header.era_id == currentBlockEraId)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }

        public async Task<int> AwaitNEraAsync(int nEra = 1)
        {
            if (nEra < 1)
            {
                throw new ArgumentOutOfRangeException("The number of Eras to wait should be equal or more than one");
            }
            var block = GetBlockLast();

            var nextNEra = block.result.block.header.era_id + nEra;

            while (block.result.block.header.era_id < nextNEra)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }

        public async Task<int> AwaitUntilNEraAsync(int untilNEraId)
        {
            var block = GetBlockLast();

            if (block.result.block.header.era_id >= untilNEraId)
            {
                throw new ArgumentOutOfRangeException($"The Era Id selected should be bigger than current Era ({block.result.block.header.era_id})");
            }

            while (block.result.block.header.era_id < untilNEraId)
            {
                await Task.Delay(ERADELAY);
                block = GetBlockLast();
            }

            return block.result.block.header.era_id;
        }
        #endregion

        #endregion

        #region Metrics
        public string GetNodeMetrics(string url)
        {
            return GetClient(url);
        }

        #endregion

        #region Node
        public NodeStatusResult GetNodeStatus()
        {
            RPCSchemaRequest request = new RPCSchemaRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<RPCSchemaRequest, NodeStatusResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region RPCSchema
        public string GetRPCShema()
        {
            RPCSchemaRequest request = new RPCSchemaRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<RPCSchemaRequest>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region StateItem
        public StateItemResult GetStateItem(string key)
        {
            var stateRootHash = GetStateRootHash();

            StateItemRequest request = new StateItemRequest(stateRootHash.result.state_root_hash, key);
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<StateItemRequest, StateItemResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        #region NodePeers
        public NodePeersResult GetNodePeers()
        {
            NodePeersRequest request = new NodePeersRequest();
            request.jsonrpc = JsonRpcVersion;
            request.id = JsonRpcId;

            return RpcClient<NodePeersRequest, NodePeersResult>(RpCUrl, request, HttpMethod.Post);
        }
        #endregion

        public K RpcClient<T, K>(string url, T request, HttpMethod httpMethod)
        {
            string result = RpcClient<T>(url, request, httpMethod);
            var temp = JsonConvert.DeserializeObject<K>(result);
            var tempResultObject = temp as Result;
            if (tempResultObject.error != null)
            {
                HandleRpcException(tempResultObject.error);
            }
            return temp;
        }

        public string RpcClient<T>(string url, T request, HttpMethod httpMethod)
        {
            string jsonString = JsonConvert.SerializeObject(request);
            var data = new StringContent(jsonString);
            using (var httpClient = new HttpClient())
            {

                HttpRequestMessage msg = new HttpRequestMessage(httpMethod, url);

                msg.Content = new StringContent(jsonString);
                msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = httpClient.SendAsync(msg).Result;

                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public K GetClient<K>(string url)
        {
            string result = GetClient(url);
            var temp = JsonConvert.DeserializeObject<K>(result);
            var tempResultObject = temp as Result;
            if (tempResultObject.error != null)
            {
                HandleRpcException(tempResultObject.error);
            }
            return temp;
        }

        public string GetClient(string Url)
        {
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, Url);

                HttpResponseMessage response = httpClient.SendAsync(msg).Result;
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }    

        private string HandleRpcException(Error error)
        {
            throw new ApplicationException(error.message);
        }
    }
}
